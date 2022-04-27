using DogTinder.IRepository;
using DogTinder.Models;
using DogTinder.Models.DataAccess;
using System;
using System.Collections.Generic;

namespace DogTinder.Repository
{
	public class OwnerRepository : IOwnerRepository
	{
		private readonly DogTinderContext Context;

		public OwnerRepository(DogTinderContext context)
		{
			Context = context;
		}

		public IEnumerable<Owner> GetAll()
		{
			return Context.Owners;
		}

		public void Insert(Owner owner)
		{
			Context.Owners.Add(owner);
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