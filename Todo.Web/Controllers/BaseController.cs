using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Web.Controllers
{
	[ApiController]
	[Authorize]
	public class BaseController : Controller
	{
		
	}
}
