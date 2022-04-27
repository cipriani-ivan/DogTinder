using DogTinder.Models;
using System.Collections.Generic;

namespace DogTinder.IRepository
{
	public interface IDogRepository
	{
		IEnumerable<Dog> GetAll();
		void Insert(Dog owner);
		void Save();
	}
}