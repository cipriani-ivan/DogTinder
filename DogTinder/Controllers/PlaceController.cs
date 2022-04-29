using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogTinder.Services.IService;

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

		[HttpGet]
		public IList<PlaceViewModel> GetPlaces()
		{
			return PlaceService.GetPlaces();
		}

		[HttpPost]
		public void PostPlaces([FromBody] PlaceViewModel placeViewModel)
		{
			PlaceService.InsertPlace(placeViewModel);
		}

	}
}
