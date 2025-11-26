using MediatR;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;

namespace MyAppApi.Application.Todos.Commands
{
    public record ChangeStatusTodoCommand(Guid Id) : IRequest<TodoGetDto>;

}
