using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.Models;

namespace DogTinder.Repository.IRepositories
{
	public interface IDogRepository
	{
		IEnumerable<Dog> GetAll();
		void Insert(Dog owner);
		void Save();
	}
}