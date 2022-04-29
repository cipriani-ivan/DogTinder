using DogTinder.EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DogTinder.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected DbContext Context;
		internal DbSet<TEntity> dbSet;
		private bool Disposed;

		protected GenericRepository(DogTinderContext context)
		{
			this.Context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> GetAll(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			query = includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return orderBy != null ? orderBy(query).ToList() : query.ToList();
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}


		public virtual void Save()
		{
			Context.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!Disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}

			Disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}