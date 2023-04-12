using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Web.Contract.Models;

namespace Todo.Web.Contract.Api.Auth.Response
{
	public class RegisterResponse: BaseResponse
	{
		public UserModel User { get; set; }
	}
}
