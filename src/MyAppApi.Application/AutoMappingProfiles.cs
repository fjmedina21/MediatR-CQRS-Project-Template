using AutoMapper;
using MyAppApi.Application.Todos.Commands;
using MyAppApi.Domain.Todos.DTO;
using MyAppApi.Domain.Todos.Entities;

namespace MyAppApi.Application
{
	public class AutoMappingProfiles : Profile
	{
		public AutoMappingProfiles()
		{
			CreateMap<Todo, TodoGetDto>();
			CreateMap<CreateOrUpdateTodoCommand, Todo>();

		}
	}
}
