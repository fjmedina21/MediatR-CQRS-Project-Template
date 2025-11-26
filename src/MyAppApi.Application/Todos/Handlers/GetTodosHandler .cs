using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAppApi.Application.Todos.Queries;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;
using MyAppApi.Infrastructure.Data;


namespace MyAppApi.Application.Todos.Handlers
{
	public class GetTodosHandler(MyAppContext context, IMapper mapper) : IRequestHandler<GetTodosQuery, List<TodoGetDto>>
	{
		public async Task<List<TodoGetDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
		{
			var todos = await context.Todos.AsNoTracking()
				.Where(e => !e.DeletedAtUtc.HasValue)
				.ToListAsync(cancellationToken);

			var dtos = mapper.Map<List<TodoGetDto>>(todos);

			return dtos;
		}
	}
}
