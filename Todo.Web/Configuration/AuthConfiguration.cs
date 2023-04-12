using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Todo.Web.Options;

namespace Todo.Web.Configuration
{
	public static class AuthConfiguration
	{
		public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, AuthOptions authOptions)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddCookie()
				.AddJwtBearer(options =>
				{
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidIssuer = authOptions.Issuer,
						ValidAudience = authOptions.Audience,
						IssuerSigningKey = authOptions.SymmetricKey
					};
				});

			services.AddAuthorization();

			return services;
		}

		public static IApplicationBuilder UseAuthConfiguration(this IApplicationBuilder appBuilder)
		{
			appBuilder.UseAuthentication();
			appBuilder.UseAuthorization();

			return appBuilder;
		}
	}
}
