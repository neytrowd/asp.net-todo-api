using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Todo.Web.Contract.Api.Auth.Request;
using Todo.Web.Contract.Api.Auth.Response;
using Todo.Web.Options;

namespace Todo.Web.Controllers
{
	[Route("api/[controller]")]
	public class AuthController : BaseController
	{
		private readonly IMediator _mediator;
		private readonly AuthOptions _authOptions;

		public AuthController(IMediator mediator, IOptions<AuthOptions> authOptions)
		{
			_mediator= mediator;
			_authOptions = authOptions.Value;
		}

		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<LoginResponse> Login(LoginRequest request)
		{
			return await _mediator.Send(new LoginRequest()
			{
				Login= request.Login,
				Password= request.Password,
			});
		}

		[HttpPost("logout")]
		[AllowAnonymous]
		public IActionResult Logout()
		{
			HttpContext.Response.Cookies.Delete(_authOptions.CookiesName, new CookieOptions
			{
				Domain = _authOptions.Domain,
			});

			return NoContent();
		}
		
		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<RegisterResponse> Register(RegisterRequest request)
		{
			return await _mediator.Send(new RegisterRequest()
			{
				NewUser= request.NewUser,
			});
		}
	}
}
