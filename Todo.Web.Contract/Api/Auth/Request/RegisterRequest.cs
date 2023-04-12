using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Web.Contract.Api.Auth.Response;
using Todo.Web.Contract.Models;

namespace Todo.Web.Contract.Api.Auth.Request
{
	public class RegisterRequest: BaseRequest<RegisterResponse>
	{
		public RegisterModel NewUser { get; set; }
	}
}
