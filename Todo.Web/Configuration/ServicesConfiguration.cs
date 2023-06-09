﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Todo.DAL.Repositories;
using Todo.Web.BLL.Mapping.Todo;
using Todo.Web.BLL.RequestHandlers.Todo.Validators;

namespace Todo.Web.Configuration
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(TodoMap));

			/*services.AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblyContaining<CreateTodoRequestValidator>();
			});*/

			services.AddFluentValidationAutoValidation();
			services.AddValidatorsFromAssemblyContaining<CreateTodoRequestValidator>();

			return services;
		}
	}
}
