using FluentResults;
using KubernetesDemo.Api.Domain.Database.Queries;
using KubernetesDemo.Api.Domain.Database.Repositories;
using KubernetesDemo.Api.Infrastructure.Database.Entities;

namespace KubernetesDemo.Api.Application.Services
{
    public class TodoItemService(
        ITodoRepository repository, 
        IToDoItemQuery query, 
        IUnitOfWork unitOfWork) : ITodoItemService
    {
        public async Task<Result> CreateTodoItemAsync(TodoItem todoItem)
        {
            await repository.AddAsync(todoItem);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<Result> DeleteTodoItemAsync(int id)
        {
            await repository.DeleteAsync(id);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync()
            => await query.GetAllAsync();

        public async Task<Result<TodoItem>> GetTodoItemByIdAsync(int id)
        {
            TodoItem? todoItem = await query.GetAsync(id);
            if (todoItem is null) return Result.Fail<TodoItem>("Item not found");

            return todoItem;
        }

        public async Task<Result> UpdateTodoItemAsync(TodoItem todoItem)
        {
            repository.Update(todoItem);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
