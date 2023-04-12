using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Todo.DAL.Migrations;
using Todo.Entities;
using Todo.Web.Options;

namespace Todo.Web.BLL.Services.Auth
{
	public class AuthService: IAuthService
	{
		private readonly AuthOptions _authOptions;

		public AuthService(IConfiguration configuration, IOptions<AuthOptions> authOptions)
		{
			_authOptions = authOptions.Value;
		}

		public string GetAccessToken(UserEntity user)
		{
			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Login),
				new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			};

			var algorithm = SecurityAlgorithms.HmacSha256;

			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authOptions.Secret)
			), algorithm);

			var token = new JwtSecurityToken(
				_authOptions.Issuer,
				_authOptions.Audience,
				claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddDays(366),
				signingCredentials);


			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	
		/*private void AppendTokenToCookieResponse(string token)
		{
			HttpContext.Response.Cookies.Append(_authOptions.CookiesName, token,
				new CookieOptions
				{
					MaxAge = TimeSpan.FromDays(366),
					Domain = _authOptions.Domain,
				});
		}*/
	}
}
