using System;
using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;

namespace DogTinder.Repository.Repositories
{
	public class OwnerRepository : IOwnerRepository
	{

		private bool Disposed;
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