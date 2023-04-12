using Todo.Web.Options;

namespace Todo.Web.Configuration
{
	public static class OptionsConfiguration
	{
		public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<AuthOptions>(configuration.GetSection("Auth"));

			return services;
		}
	}
}
