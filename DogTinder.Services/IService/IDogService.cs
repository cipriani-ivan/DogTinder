using DogTinder.ViewModels;
using System.Collections.Generic;

namespace DogTinder.IServices
{
	public interface IDogService
	{
		IList<DogViewModel> GetDogs();
		void InsertDog(DogViewModel dogViewmodel);
	}
}