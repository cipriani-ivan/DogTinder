using System;
using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;

namespace DogTinder.Repository.Repositories
{
	public class PlaceRepository : IPlaceRepository
	{
		private bool Disposed;
		private readonly DogTinderContext Context;

		public PlaceRepository(DogTinderContext context)
		{
			Context = context;
		}

		public IEnumerable<Place> GetAll()
		{
			return Context.Places;
		}

		public void Insert(Place place)
		{
			Context.Places.Add(place);
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