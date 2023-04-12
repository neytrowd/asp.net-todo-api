using Todo.Entities;

namespace Todo.Web.Models
{
	public class TodoEntity:IEntityBase<long>
	{
		public long Id { get; set; }

		public string Title { get; set; }

		public bool IsCompleted { get; set; }
	}
}
