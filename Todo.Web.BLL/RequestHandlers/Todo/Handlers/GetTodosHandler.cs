using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Contract.Api.Todo.Request;
using Todo.Web.Contract.Api.Todo.Response;

namespace Todo.Web.BLL.RequestHandlers.Todo.Handlers
{
	public class GetTodosHandler: BaseRequestHandler<GetTodosRequest, GetTodosResponse>
	{
		private readonly ITodoRepository _todoRepository;

		public GetTodosHandler(IHttpContextAccessor httpContext, IMapper mapper, ITodoRepository todoRepository) : base(httpContext, mapper)
		{
			_todoRepository = todoRepository;
		}

		public override async Task<GetTodosResponse> Handle(GetTodosRequest request, CancellationToken cancellationToken)
		{
			var result = _todoRepository.GetAll();

			return new GetTodosResponse
			{
				Todos = (List<Models.TodoEntity>)result
			};
		}
	}
}
