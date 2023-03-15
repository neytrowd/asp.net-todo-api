﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.DAL.Data;

namespace Todo.DAL.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		protected TodoDbContext _context { get; set; }
		protected DbSet<TEntity> _dbSet { get; set; }

		public BaseRepository(TodoDbContext context) {
			_context= context;
			_dbSet= context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return _dbSet.ToList();
		}

		public virtual void Add(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			_dbSet.Remove(entity);
		}

		public virtual void Update(TEntity entity)
		{
			_dbSet.Update(entity);
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
	}
}