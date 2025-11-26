using MyAppApi.Domain.Todos.DTO;

namespace MyAppApi.Application.Hubs
{
    public interface INotificationsClient
    {
        Task TodoCreated(TodoGetDto todo);
        Task TodoUpdated(TodoGetDto todo);
        Task TodoDeleted(Guid id);
    }
}
