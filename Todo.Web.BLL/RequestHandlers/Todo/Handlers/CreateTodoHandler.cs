using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Contract.Api.Todo.Request;
using Todo.Web.Contract.Api.Todo.Response;
using Todo.Web.Models;
using Newtonsoft.Json;
using Todo.Web.Contract.Models;
using AutoMapper;

namespace Todo.Web.BLL.RequestHandlers.Todo.Handlers
{
	public class CreateTodoHandler : BaseRequestHandler<CreateTodoRequest, CreateTodoResponse>
	{
		private readonly IMapper _mapper;
		private readonly ITodoRepository _todoRepository;

		public CreateTodoHandler(ITodoRepository todoRepository, IMapper mapper)
		{
			_mapper = mapper;
			_todoRepository = todoRepository;
		}

		public override async Task<CreateTodoResponse> Handle(CreateTodoRequest request, CancellationToken token)
		{
			/*var todoEntity = JsonConvert.DeserializeObject<TodoEntity>(JsonConvert.SerializeObject(request.Todo));*/
			var todoEntity = _mapper.Map<TodoEntity>(request.Todo);

			_todoRepository.Add(todoEntity);

			_todoRepository.SaveChanges();

			var todoModel = _mapper.Map<TodoModel>(todoEntity);

			return new CreateTodoResponse
			{
				Todo = todoModel
			};
		}
	}
}
