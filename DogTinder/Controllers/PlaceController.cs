using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		public async Task<IList<PlaceViewModel>> GetPlaces()
		{
			return await PlaceService.GetPlaces();
		}

		[HttpPost]
		public async Task PostPlaces([FromBody] PlaceViewModel placeViewModel)
		{
			await PlaceService.InsertPlace(placeViewModel);
		}

	}
}
