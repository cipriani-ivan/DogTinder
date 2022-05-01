using System.Collections.Generic;
using System.Threading.Tasks;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IDogService
	{
		Task<IList<DogViewModel>> GetDogs();
		Task InsertDog(DogViewModel dogViewmodel);
	}
}