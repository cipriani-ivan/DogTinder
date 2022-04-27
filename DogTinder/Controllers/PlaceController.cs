using DogTinder.IServices;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PlaceController : ControllerBase
	{
		private readonly IPlaceService PlaceService;


		public PlaceController(IPlaceService placeService)
		{
			PlaceService = placeService;
		}

		// GET: OwnerController/Create
		public IList<PlaceViewModel> GetPlaces()
		{
			return PlaceService.GetPlaces();
		}

		// POST: OwnerController/Create
		[HttpPost]
		public void PostPlaces(PlaceViewModel placeViewModel)
		{
			PlaceService.InsertPlace(placeViewModel);
		}

	}
}
