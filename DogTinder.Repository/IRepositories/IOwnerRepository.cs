using DogTinder.Models;
using System.Collections.Generic;

namespace DogTinder.IRepository
{
	public interface IOwnerRepository
	{
		IEnumerable<Owner> GetAll();
		void Insert(Owner owner);
		void Save();
	}
}