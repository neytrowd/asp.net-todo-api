namespace Todo.Web.Models
{
	public class TodoEntity
	{
		public long Id { get; set; }

		public string Title { get; set; }

		public bool IsCompleted { get; set; }
	}
}
