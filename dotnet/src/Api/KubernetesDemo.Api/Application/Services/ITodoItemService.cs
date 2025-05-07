using FluentResults;
using KubernetesDemo.Api.Infrastructure.Database.Entities;

namespace KubernetesDemo.Api.Application.Services
{
    public interface ITodoItemService
    {
        Task<Result> CreateTodoItemAsync(TodoItem todoItem);
        Task<Result<TodoItem>> GetTodoItemByIdAsync(int id);
        Task<List<TodoItem>> GetAllTodoItemsAsync();
        Task<Result> UpdateTodoItemAsync(TodoItem todoItem);
        Task<Result> DeleteTodoItemAsync(int id);
    }
}
