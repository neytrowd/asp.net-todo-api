using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Todo.DAL.Repositories.Todo;
using Todo.Web.Models;

namespace Todo.Web.Controllers
{
	[Route("api/todos")]
	public class TodoController : Controller
	{
		protected readonly ITodoRepository _repository;

		public TodoController(ITodoRepository repository)
		{
			_repository= repository;
		}

		[HttpGet]
		public async Task<IEnumerable<TodoItem>> GetTodos()
		{
			var result = _repository.GetAll();

			return result;
		}

		[HttpPost]
		public async Task<long> CreateTodo(TodoItem todoItem)
		{
			_repository.Add(todoItem);

			_repository.SaveChanges();

			return todoItem.Id;
		}
	}
}
