using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
		public async Task<HttpResponseMessage> PostPlaces([FromBody] PlaceViewModel placeViewModel)
		{
			if (!ModelState.IsValid) return new HttpResponseMessage(HttpStatusCode.BadRequest);
			await PlaceService.InsertPlace(placeViewModel);
			return new HttpResponseMessage(HttpStatusCode.Created);
		}

	}
}
