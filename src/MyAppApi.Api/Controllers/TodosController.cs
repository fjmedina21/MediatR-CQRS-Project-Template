using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAppApi.Application.Todos.Commands;
using MyAppApi.Application.Todos.Queries;

namespace MyAppApi.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodosController(IMediator _mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _mediator.Send(new GetTodosQuery());
			return StatusCode(200, result);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await _mediator.Send(new GetTodoByIdQuery(id));
			return StatusCode(200, result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateTodoCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, CreateOrUpdateTodoCommand command)
		{
			var commandWithId = command with { Id = id };
			var result = await _mediator.Send(commandWithId);
			return StatusCode(200, result);
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _mediator.Send(new DeleteTodoCommand(id));
			return StatusCode(200, result);
		}

		[HttpPost("{id:guid}/change-state")]
		public async Task<IActionResult> ChangeStatus(Guid id)
		{
			var result = await _mediator.Send(new ChangeStatusTodoCommand(id));
			return StatusCode(200, result);
		}
	}
}
