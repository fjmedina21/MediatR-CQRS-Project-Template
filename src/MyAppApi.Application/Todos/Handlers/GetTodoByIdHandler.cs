using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAppApi.Application.Todos.Queries;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;
using MyAppApi.Infrastructure.Data;


namespace MyAppApi.Application.Todos.Handlers
{
    public class GetTodoByIdHandler(MyAppContext context, IMapper mapper) : IRequestHandler<GetTodoByIdQuery, TodoGetDto?>
    {
        public async Task<TodoGetDto?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            Todo? todo = await context.Todos.AsNoTracking()
                .Where(e => !e.DeletedAtUtc.HasValue)
                .FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);
            var dto = mapper.Map<TodoGetDto>(todo);
            return dto;
        }
    }
}
