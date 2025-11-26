using Microsoft.AspNetCore.SignalR;
using MyAppApi.Application.Hubs;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;

namespace MyAppApi.Application.Notifications
{
    public class NotificationsService(IHubContext<NotificationsHub, INotificationsClient> context)
    {
        public async Task NotifyTodoCreated(TodoGetDto todo)
        {
            await context.Clients.All.TodoCreated(todo);
        }

        public async Task NotifyTodoUpdated(TodoGetDto todo)
        {
            await context.Clients.All.TodoUpdated(todo);
        }

        public async Task NotifyTodoDeleted(Guid id)
        {
            await context.Clients.All.TodoDeleted(id);
        }

    }
}
