using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Todo.Web.Contract.Api.Todo.Request;
using Todo.Web.Contract.Models;

namespace Todo.Web.BLL.RequestHandlers.Todo.Validators
{
	public class CreateTodoRequestValidator: AbstractValidator<CreateTodoRequest>
	{
		public CreateTodoRequestValidator() {
			RuleFor(x => x.Todo).SetValidator(new TodoModelValidator());
		}

		private class TodoModelValidator: AbstractValidator<TodoModel>
		{
			public TodoModelValidator()
			{
				RuleFor(x => x.Title).NotEmpty();
				RuleFor(x => x.IsCompleted).NotEmpty();
			}
		}
	}
}
