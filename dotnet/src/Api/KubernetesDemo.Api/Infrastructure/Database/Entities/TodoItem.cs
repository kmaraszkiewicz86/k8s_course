namespace KubernetesDemo.Api.Infrastructure.Database.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsDone { get; set; }
    }
}
