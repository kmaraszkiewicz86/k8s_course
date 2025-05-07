using FluentResults;
using KubernetesDemo.Api.Infrastructure.Database.Entities;

namespace KubernetesDemo.Api.Domain.Database.Repositories
{
    public interface ITodoRepository
    {
        Task AddAsync(TodoItem todo);
        Task<Result> DeleteAsync(int id);
        void Update(TodoItem todo);
    }
}
