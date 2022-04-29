using System;
using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DogTinder.Repository.Repositories
{
	public class DogRepository : IDogRepository
	{
		private bool Disposed;
		private readonly DogTinderContext Context;

		public DogRepository(DogTinderContext context)
		{
			Context = context;
		}

		public IEnumerable<Dog> GetAll()
		{
			return Context.Dogs.Include(a => a.Owner);
		}

		public void Insert(Dog dog)
		{
			Context.Dogs.Add(dog);
		}

		public void Save()
		{
			Context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
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