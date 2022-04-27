using DogTinder.ViewModels;
using System.Collections.Generic;

namespace DogTinder.IServices
{
	public interface IPlaceService
	{
		IList<PlaceViewModel> GetPlaces();
		void InsertPlace(PlaceViewModel placeViewmodel);
	}
}