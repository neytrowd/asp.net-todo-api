﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Entities;
using Todo.Web.Models;

namespace Todo.DAL.Data
{
	public class TodoDbContext: DbContext
	{
		public DbSet<TodoEntity> TodoItems { get; set; }

		public DbSet<UserEntity> UserItems { get; set; }

		public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
