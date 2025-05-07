using Carter;
using KubernetesDemo.Api.Application.Services;
using KubernetesDemo.Api.Domain.Database.Queries;
using KubernetesDemo.Api.Domain.Database.Repositories;
using KubernetesDemo.Api.Infrastructure.Database;
using KubernetesDemo.Api.Infrastructure.Database.Queries;
using KubernetesDemo.Api.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("inmemorydatbase"));
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IToDoItemQuery, ToDoItemQuery>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddCarter();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TodoContext>();
    await context.Database.EnsureCreatedAsync();
}

app.MapCarter();
app.MapOpenApi();

app.Run();
