using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Web.BLL.Services.Auth
{
	public interface IAuthService
	{
		public string GetAccessToken(UserEntity user);
	}
}
