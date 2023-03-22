using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL.Data;
using Todo.Web.Models;

namespace Todo.DAL.Repositories.Todo
{
	public class TodoRepository: BaseRepository<TodoEntity> , ITodoRepository
	{
		public TodoRepository(TodoDbContext context): base(context) { }
	}
}
