using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAppApi.Application.Notifications;
using MyAppApi.Application.Todos.Commands;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;
using MyAppApi.Infrastructure.Data;

namespace MyAppApi.Application.Todos.Handlers
{
    public class ChangeStatusTodoHandler(MyAppContext context,IMapper mapper, NotificationsService notificationService) : IRequestHandler<ChangeStatusTodoCommand, TodoGetDto>
    {
        public async Task<TodoGetDto> Handle(ChangeStatusTodoCommand request, CancellationToken cancellationToken)
        {
            Todo? todo = await context.Todos
                .Where(e => !e.DeletedAtUtc.HasValue)
                .FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);

            todo.IsCompleted = !todo.IsCompleted;
            todo.CompletedAtUtc = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);

            var dto = mapper.Map<TodoGetDto>(todo);
            await notificationService.NotifyTodoUpdated(dto);
            return dto;
        }
    }
}
