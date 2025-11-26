using MediatR;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;

namespace MyAppApi.Application.Todos.Commands
{
    public record CreateOrUpdateTodoCommand(Guid? Id, string Title) : IRequest<TodoGetDto>;

}
