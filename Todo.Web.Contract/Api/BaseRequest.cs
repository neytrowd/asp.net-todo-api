using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Todo.Web.Contract.Api
{
	public class BaseRequest<TResponse>: IRequest<TResponse>
	{
		public string RequestId { get; set; } = Guid.NewGuid().ToString();
	}
}
