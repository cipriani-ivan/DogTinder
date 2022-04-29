using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DogTinder.Repository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> GetAll(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");

		void Insert(TEntity entity);
		void Save();
		void Dispose(bool disposing);
		void Dispose();
	}
}