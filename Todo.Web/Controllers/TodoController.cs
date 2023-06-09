﻿using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Contract.Api.Todo.Request;
using Todo.Web.Contract.Api.Todo.Response;
using Todo.Web.Contract.Models;
using Todo.Web.Models;
using Todo.Web.Options;

namespace Todo.Web.Controllers
{
	[Route("api/[controller]")]
	public class TodoController : BaseController
	{
		private readonly IMediator _mediator;

		public TodoController(IMediator mediator)
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
			return await _mediator.Send(new CreateTodoRequest()
			{
				Todo = request.Todo,
			});
		}
	}
}
