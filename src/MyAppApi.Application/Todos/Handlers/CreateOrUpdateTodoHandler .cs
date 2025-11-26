using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyAppApi.Application.Notifications;
using MyAppApi.Application.Todos.Commands;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;
using MyAppApi.Infrastructure.Data;


namespace MyAppApi.Application.Todos.Handlers
{
	public class CreateOrUpdateTodoHandler(MyAppContext context, IMapper mapper, NotificationsService notificationService) : IRequestHandler<CreateOrUpdateTodoCommand, TodoGetDto>
	{
		public async Task<TodoGetDto> Handle(CreateOrUpdateTodoCommand request, CancellationToken cancellationToken)
		{
			Todo todo = mapper.Map<Todo>(request);
			EntityEntry<Todo> entry;
			if (!request.Id.HasValue || !await context.Todos.AnyAsync(e => e.Id.Equals(request.Id.Value), cancellationToken))
			{
				todo.Id = Guid.NewGuid();
				entry = context.Todos.Attach(todo);
				entry.State = EntityState.Added;
			}
			else
			{
				todo = new Todo { Id = request.Id.Value, Title = request.Title };
				entry = context.Todos.Attach(todo);
				entry.State = EntityState.Modified;
				entry.Property(e => e.Id).IsModified = false;
			}

			await context.SaveChangesAsync(cancellationToken);
			var dto = mapper.Map<TodoGetDto>(entry.Entity);

			switch (entry.State)
			{
				case EntityState.Added:
					await notificationService.NotifyTodoCreated(dto);
					break;
				case EntityState.Modified:
					await notificationService.NotifyTodoUpdated(dto);
					break;
			}

			return dto;
		}
	}
}
