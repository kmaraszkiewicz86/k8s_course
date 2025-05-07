using FluentResults;
using KubernetesDemo.Api.Domain.Database.Repositories;

namespace KubernetesDemo.Api.Infrastructure.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _ctx;
        public UnitOfWork(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Result> SaveChangesAsync()
        {
            try
            {
                await _ctx.SaveChangesAsync();
                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Something went wrong when trying to update database");
            }
        }
    }
}
