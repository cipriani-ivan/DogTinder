using DogTinder.IRepository;
using DogTinder.Models;
using DogTinder.Models.DataAccess;
using System;
using System.Collections.Generic;

namespace DogTinder.Repository
{
	public class PlaceRepository : IPlaceRepository
	{
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