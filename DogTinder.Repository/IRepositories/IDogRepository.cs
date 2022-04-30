using DogTinder.EFDataAccessLibrary.Models;

namespace DogTinder.Repository.IRepositories
{
	public interface IDogRepository: IGenericRepository<Dog>
	{
		void Insert(Dog dog, int ownerId);
	}
}