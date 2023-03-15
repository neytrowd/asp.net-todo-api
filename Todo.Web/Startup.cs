using Microsoft.EntityFrameworkCore;
using Todo.DAL.Data;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Configuration;

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
			
			services.AddControllersWithViews();
			services.AddDatabaseConfiguration(Configuration);

			services.AddSwaggerGen();
			services.AddScoped<ITodoRepository, TodoRepository>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseRouting();

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
