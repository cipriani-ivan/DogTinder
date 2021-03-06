using DogTinder.EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DogTinder.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected DbContext Context;
		internal DbSet<TEntity> dbSet;
		private bool Disposed;

		protected GenericRepository(DogTinderContext context)
		{
			Context = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			query = includeProperties.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries)
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return orderBy != null ? await  orderBy(query).ToListAsync() : await  query.ToListAsync();
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Update(TEntity entity)
		{
			dbSet.Update(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			dbSet.Remove(entity);
		}


		public virtual async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
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