using System.Collections.Generic;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IDogService
	{
		IList<DogViewModel> GetDogs();
		void InsertDog(DogViewModel dogViewmodel);
	}
}