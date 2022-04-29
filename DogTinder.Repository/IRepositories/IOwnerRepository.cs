using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.Models;

namespace DogTinder.Repository.IRepositories
{
	public interface IOwnerRepository
	{
		IEnumerable<Owner> GetAll();
		void Insert(Owner owner);
		void Save();
	}
}