using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.DAL.Repositories
{
	public interface IBaseRepository<TEntity>
	{
		IEnumerable<TEntity> GetAll();

		void Add(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);

		int SaveChanges();

		Task<int> SaveChangesAsync(CancellationToken token = default);
	}
}
