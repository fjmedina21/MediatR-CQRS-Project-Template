using MediatR;
using MyAppApi.Domain.Todos.DTO;

namespace MyAppApi.Application.Todos.Queries
{
    public record GetTodoByIdQuery(Guid Id) : IRequest<TodoGetDto?>;
}
