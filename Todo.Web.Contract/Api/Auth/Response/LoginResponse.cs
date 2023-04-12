using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Web.Contract.Models;

namespace Todo.Web.Contract.Api.Auth.Response
{
	public class LoginResponse: BaseResponse
	{
		public UserModel User { get; set; }

		public string AccessToken { get; set; }
	}
}
