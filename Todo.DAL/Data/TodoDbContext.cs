using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Models;

namespace Todo.DAL.Data
{
	public class TodoDbContext: DbContext
	{
		public DbSet<TodoItem> TodoItems { get; set; }

		public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
