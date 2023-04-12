using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Todo.DAL.Repositories.Todo;
using Todo.DAL.Repositories.User;
using Todo.Entities;
using Todo.Web.Contract.Api.Auth.Request;
using Todo.Web.Contract.Api.Auth.Response;
using Todo.Web.Contract.Models;
using Todo.Common.Utils;

namespace Todo.Web.BLL.RequestHandlers.Auth.Handlers
{
	public class RegisterHandler: BaseRequestHandler<RegisterRequest, RegisterResponse>
	{
		private readonly IUserRepository _userRepository;

		public RegisterHandler(IHttpContextAccessor httpContext, IMapper mapper, IUserRepository userRepository) : base(httpContext, mapper)
		{
			_userRepository = userRepository;
		}

		public override async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken token)
		{
			var newUser = request.NewUser;

			var userWithSameLogin = await _userRepository.GetOneWhereAsync(user => user.Login == newUser.Email);

			if (userWithSameLogin != null)
			{
				throw new Exception("User with same login");
			}

			var user = new UserEntity
			{
				Name = newUser.Name,
				Login = newUser.Email,
				HashedPassword = HashUtil.Hash(newUser.Password),
			};

			_userRepository.Add(user);
			await _userRepository.SaveChangesAsync();

			var userModel = _mapper.Map<UserModel>(user);

			return new RegisterResponse{
				User = userModel,
			};
		}
	}
}
