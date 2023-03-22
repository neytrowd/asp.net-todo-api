using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Contract.Api.Todo.Request;
using Todo.Web.Contract.Api.Todo.Response;
using Todo.Web.Contract.Models;
using Todo.Web.Models;

namespace Todo.Web.Controllers
{
	[Route("api/todos")]
	[ApiController]
	public class TodoController : Controller
	{
		protected readonly IMediator _mediator;

		public TodoController(ITodoRepository repository, IMediator mediator)
		{
			_mediator= mediator;
		}

		[HttpGet]
		public async Task<GetTodosResponse> GetTodos()
		{
			return await _mediator.Send(new GetTodosRequest());
		}

		[HttpPost]
		public async Task<CreateTodoResponse> CreateTodo(CreateTodoRequest request)
		{
			Console.WriteLine(ModelState.IsValid);

			return await _mediator.Send(new CreateTodoRequest()
			{
				Todo = request.Todo,
			});
		}
	}
}
