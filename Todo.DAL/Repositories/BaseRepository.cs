using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		public Task<int> SaveChangesAsync(CancellationToken token = default)
		{
			return _context.SaveChangesAsync(token);
		}

		public virtual Task<TEntity> GetOneWhereAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
		{
			return WithIncludes(_dbSet, includes).SingleOrDefaultAsync(predicate);
		}

		protected IQueryable<TEntity> WithIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
		{
			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}

			return query;
		}
	}
}
