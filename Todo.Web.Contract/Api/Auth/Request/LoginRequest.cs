using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Web.Contract.Api.Auth.Response;

namespace Todo.Web.Contract.Api.Auth.Request
{
	public class LoginRequest: BaseRequest<LoginResponse>
	{
		public string Login { get; set; }

		public string Password { get; set; }
	}
}
