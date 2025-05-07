using Carter;
using KubernetesDemo.Api.Application.Services;
using KubernetesDemo.Api.Infrastructure.Database.Entities;

namespace KubernetesDemo.Api.Endpoints
{
    public class TodoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/TodoItem", async (ITodoItemService service) => 
                await service.GetAllTodoItemsAsync());

            app.MapGet("api/TodoItem/{id:int}", async (int id, ITodoItemService service) =>
                await service.GetTodoItemByIdAsync(id));

            app.MapPost("api/TodoItem", async (TodoItem request, ITodoItemService service) =>
                await service.CreateTodoItemAsync(request));

            app.MapPut("api/TodoItem", async (TodoItem request, ITodoItemService service) =>
                await service.UpdateTodoItemAsync(request));

            app.MapDelete("api/TodoItem/{id:int}", async (int id, ITodoItemService service) =>
                await service.DeleteTodoItemAsync(id));
        }
    }
}
