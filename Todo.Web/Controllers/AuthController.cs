using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Web.Contract.Api.Auth.Request;
using Todo.Web.Contract.Api.Auth.Response;

namespace Todo.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : Controller
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator= mediator;
		}

		[HttpPost("login")]
		public async Task<LoginResponse> Login(LoginRequest request)
		{
			return await _mediator.Send(new LoginRequest()
			{
				Login= request.Login,
				Password= request.Password,
			});
		}

		
		[HttpPost("register")]
		public async Task<RegisterResponse> Register(RegisterRequest request)
		{
			return await _mediator.Send(new RegisterRequest()
			{
				NewUser= request.NewUser,
			});
		}
	}
}
