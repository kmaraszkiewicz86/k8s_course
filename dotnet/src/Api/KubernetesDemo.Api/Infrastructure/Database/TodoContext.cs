using KubernetesDemo.Api.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace KubernetesDemo.Api.Infrastructure.Database
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<TodoItem> todoItems = new();

            for (int i = 1; i <= 10; i++)
            {
                todoItems.Add(new TodoItem
                {
                    Id = i,
                    Title = $"Todo {i}",
                    IsDone = false
                });
            }

            modelBuilder.Entity<TodoItem>()
                .HasData(todoItems);

            base.OnModelCreating(modelBuilder);
        }
    }
}
