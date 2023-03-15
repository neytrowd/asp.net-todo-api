using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Todo.Web.BLL.RequestHandlers
{
	public abstract class BaseRequestHandler<TRequest, TResponse>: IRequestHandler<TRequest, TResponse>
		where TRequest: IRequest<TResponse>
	{
		public abstract Task<TResponse> Handle(TRequest request, CancellationToken token);
	}
}
