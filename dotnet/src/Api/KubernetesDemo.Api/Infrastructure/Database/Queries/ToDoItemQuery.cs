using KubernetesDemo.Api.Domain.Database.Queries;
using KubernetesDemo.Api.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace KubernetesDemo.Api.Infrastructure.Database.Queries
{
    public class ToDoItemQuery(TodoContext context) : IToDoItemQuery
    {
        public async Task<List<TodoItem>> GetAllAsync()
            => await context.Todos.ToListAsync();

        public async Task<TodoItem?> GetAsync(int id)
            => await context.Todos.FindAsync(id);
    }
}
