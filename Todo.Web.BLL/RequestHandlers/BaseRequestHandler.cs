using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Todo.Web.BLL.RequestHandlers
{
	public abstract class BaseRequestHandler<TRequest, TResponse>: IRequestHandler<TRequest, TResponse>
		where TRequest: IRequest<TResponse>
	{
		protected readonly IHttpContextAccessor _httpContext;
		protected readonly IMapper _mapper;

		public BaseRequestHandler(IHttpContextAccessor httpContext, IMapper mapper)
		{
			_httpContext= httpContext;
			_mapper= mapper;
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken token);
	}
}
