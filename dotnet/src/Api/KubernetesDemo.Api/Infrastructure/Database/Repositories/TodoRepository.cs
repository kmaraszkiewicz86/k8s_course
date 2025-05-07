using FluentResults;
using KubernetesDemo.Api.Domain.Database.Repositories;
using KubernetesDemo.Api.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace KubernetesDemo.Api.Infrastructure.Database.Repositories
{
    public class TodoRepository(TodoContext context) : ITodoRepository
    {
        public async Task AddAsync(TodoItem todo)
        {
            await context.Todos.AddAsync(todo);
        }

        public void Update(TodoItem todo)
        {
            context.Entry(todo).State = EntityState.Modified;
            context.Update(todo);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var toDoItem = await context.Todos.FindAsync(id);
            if (toDoItem is null)
                return Result.Fail("Item not found");

            context.Todos.Remove(toDoItem);
            return Result.Ok();
        }
    }
}
