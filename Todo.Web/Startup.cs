using Microsoft.EntityFrameworkCore;
using Todo.DAL.Data;
using Todo.DAL.Repositories.Todo;
using Todo.DAL.Repositories.User;
using Todo.Web.BLL.Services.Auth;
using Todo.Web.Configuration;
using Todo.Web.Options;

namespace Todo.Web
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptionsConfiguration(Configuration);
			services.AddHttpContextAccessor();
			services.AddControllersWithViews();
			services.AddDatabaseConfiguration(Configuration);
			services.AddAuthConfiguration(Configuration.GetSection("Auth").Get<AuthOptions>());
			services.AddMediatrConfiguration();
			services.AddServicesConfiguration();
			services.AddSwaggerGen();

			services.AddScoped<ITodoRepository, TodoRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			services.AddScoped<IAuthService, AuthService>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseRouting();
			app.UseAuthConfiguration();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseSwagger();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
