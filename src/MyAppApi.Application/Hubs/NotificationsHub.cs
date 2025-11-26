using Microsoft.AspNetCore.SignalR;

namespace MyAppApi.Application.Hubs
{
    public class NotificationsHub : Hub<INotificationsClient>
    {
    }
}
