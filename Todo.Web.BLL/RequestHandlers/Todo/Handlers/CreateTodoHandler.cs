using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Contract.Api.Todo.Request;
using Todo.Web.Contract.Api.Todo.Response;
using Todo.Web.Models;

namespace Todo.Web.BLL.RequestHandlers.Todo.Handlers
{
	public class CreateTodoHandler : BaseRequestHandler<CreateTodoRequest, CreateTodoResponse>
	{
		private readonly ITodoRepository _todoRepository;

		public CreateTodoHandler(ITodoRepository todoRepository)
		{
			_todoRepository= todoRepository;
		}

		public override async Task<CreateTodoResponse> Handle(CreateTodoRequest request, CancellationToken token)
		{
			var todo = request.Todo;

			_todoRepository.Add(todo);

			_todoRepository.SaveChanges();

			return new CreateTodoResponse
			{
				Todo = todo
			};
		}
	}
}
