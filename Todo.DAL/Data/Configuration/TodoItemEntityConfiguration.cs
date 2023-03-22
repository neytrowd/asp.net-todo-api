using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Web.Models;

namespace Todo.DAL.Data.Configuration
{
	public class TodoItemEntityConfiguration: IEntityTypeConfiguration<TodoEntity>
	{
		public void Configure(EntityTypeBuilder<TodoEntity> builder) 
		{
			builder.ToTable("Todos");
		}
	}
}
