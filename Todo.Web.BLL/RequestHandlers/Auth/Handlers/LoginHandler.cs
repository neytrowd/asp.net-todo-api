using AutoMapper;
using Microsoft.AspNetCore.Http;
using Todo.Common.Utils;
using Todo.DAL.Repositories.User;
using Todo.Web.BLL.Services.Auth;
using Todo.Web.Contract.Api.Auth.Request;
using Todo.Web.Contract.Api.Auth.Response;
using Todo.Web.Contract.Models;

namespace Todo.Web.BLL.RequestHandlers.Auth.Handlers
{
	public class LoginHandler: BaseRequestHandler<LoginRequest, LoginResponse>
	{
		private readonly IUserRepository _userRepository;
		private readonly IAuthService _authService;

		public LoginHandler(IHttpContextAccessor httpContext, IMapper mapper, IUserRepository userRepository, IAuthService authService) : base(httpContext, mapper)
		{
			_authService = authService;
			_userRepository = userRepository;
		}

		public override async Task<LoginResponse> Handle(LoginRequest request, CancellationToken token)
		{
			var user = await _userRepository.GetOneWhereAsync(user => user.Login == request.Login);

			var equal = HashUtil.VerifyEquality(user.HashedPassword, request.Password);

			if (user == null || !HashUtil.VerifyEquality(user.HashedPassword, request.Password))
			{
				throw new Exception("User not found");
			}

			var access_token = _authService.GetAccessToken(user);

			var userModel = _mapper.Map<UserModel>(user);

			return new LoginResponse()
			{
				User = userModel,
				AccessToken = access_token
			};
		}
	}
}
