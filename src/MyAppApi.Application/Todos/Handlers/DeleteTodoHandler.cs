using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAppApi.Application.Notifications;
using MyAppApi.Application.Todos.Commands;
using MyAppApi.Domain.Todos.Entities;
using MyAppApi.Infrastructure.Data;


namespace MyAppApi.Application.Todos.Handlers
{
	public class DeleteTodoHandler(MyAppContext context, NotificationsService notificationService) : IRequestHandler<DeleteTodoCommand, bool>
	{
		public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
		{
			Todo? todo = await context.Todos.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

			if (todo == null) return false;

			todo.DeletedAtUtc = DateTime.UtcNow;

			int deleted = await context.SaveChangesAsync(cancellationToken);
			await notificationService.NotifyTodoDeleted(request.Id);

			return deleted > 0;
		}
	}
}
