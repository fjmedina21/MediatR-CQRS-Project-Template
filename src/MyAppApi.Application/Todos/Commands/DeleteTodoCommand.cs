using MediatR;

namespace MyAppApi.Application.Todos.Commands
{
    public record DeleteTodoCommand(Guid Id) : IRequest<bool>;

}
