using System.Collections.Generic;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IPlaceService
	{
		IList<PlaceViewModel> GetPlaces();
		void InsertPlace(PlaceViewModel placeViewmodel);
	}
}