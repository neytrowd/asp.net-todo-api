using Microsoft.Extensions.DependencyInjection;
using Todo.Web.BLL.RequestHandlers;

namespace Todo.Web.Configuration
{
	public static class MediatrConfiguration
	{
		public static IServiceCollection AddMediatrConfiguration(this IServiceCollection services)
		{
			services.AddMediatR(configuration =>
			{
				configuration.RegisterServicesFromAssembly(typeof(BaseRequestHandler<,>).Assembly);
			});

			return services;
		}
	}
}
