using FluentResults;

namespace KubernetesDemo.Api.Domain.Database.Repositories
{
    public interface IUnitOfWork
    {
        Task<Result> SaveChangesAsync();
    }
}
