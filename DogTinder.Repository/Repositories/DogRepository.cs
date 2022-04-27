using DogTinder.IRepository;
using DogTinder.Models;
using DogTinder.Models.DataAccess;
using System;
using System.Collections.Generic;

namespace DogTinder.Repository
{
	public class DogRepository : IDogRepository
	{
		private readonly DogTinderContext Context;

		public DogRepository(DogTinderContext context)
		{
			Context = context;
		}

		public IEnumerable<Dog> GetAll()
		{
			return Context.Dogs;
		}

		public void Insert(Dog dog)
		{
			Context.Dogs.Add(dog);
		}

		public void Save()
		{
			Context.SaveChanges();
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}