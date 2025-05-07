using KubernetesDemo.UI.Client.Models;
using Refit;

namespace KubernetesDemo.UI.Client.Services
{
    public interface ITodoApi
    {
        [Get("/api/TodoItem")]
        Task<List<TodoItem>> GetTodosAsync();

        [Post("/api/TodoItem")]
        Task<TodoItem> CreateTodoAsync([Body] TodoItem todo);

        [Put("/api/TodoItem")]
        Task UpdateTodoAsync([Body] TodoItem todo);

        [Delete("/api/TodoItem/{id}")]
        Task DeleteTodoAsync(int id);
    }
}
