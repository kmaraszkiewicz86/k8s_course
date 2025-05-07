using KubernetesDemo.Api.Infrastructure.Database.Entities;

namespace KubernetesDemo.Api.Domain.Database.Queries
{
    public interface IToDoItemQuery
    {
        Task<TodoItem?> GetAsync(int id);
        Task<List<TodoItem>> GetAllAsync();
    }
}
