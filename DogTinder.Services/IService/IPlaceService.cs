using System.Collections.Generic;
using System.Threading.Tasks;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IPlaceService
	{
		Task<IList<PlaceViewModel>> GetPlaces();
		Task InsertPlace(PlaceViewModel placeViewmodel);
	}
}