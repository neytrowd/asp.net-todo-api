using Microsoft.EntityFrameworkCore;
using Todo.DAL.Data;
using Todo.DAL.Repositories.Todo;

namespace Todo.Web.Configuration
{
	public static class DatabaseConfiguration
	{
		public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			services.AddDbContext<TodoDbContext>(options =>
			{
				var connectionString = configuration.GetConnectionString("Todos");
				options.UseNpgsql(connectionString, builder =>
				{
					builder.UseRelationalNulls(true);
				}).EnableSensitiveDataLogging();
			});

			return services;
		}
	}
}
