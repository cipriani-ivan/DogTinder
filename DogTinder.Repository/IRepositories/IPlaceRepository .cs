using DogTinder.Models;
using System.Collections.Generic;

namespace DogTinder.IRepository
{
	public interface IPlaceRepository
	{
		IEnumerable<Place> GetAll();
		void Insert(Place owner);
		void Save();
	}
}