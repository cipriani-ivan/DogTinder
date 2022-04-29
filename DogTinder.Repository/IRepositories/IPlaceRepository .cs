using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.Models;

namespace DogTinder.Repository.IRepositories
{
	public interface IPlaceRepository
	{
		IEnumerable<Place> GetAll();
		void Insert(Place owner);
		void Save();
	}
}