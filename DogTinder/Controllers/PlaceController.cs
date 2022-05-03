using System;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DogTinder.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PlaceController : ControllerBase
	{
		private readonly IPlaceService PlaceService;
		private readonly ILogger Logger;

		public PlaceController(IPlaceService placeService, ILoggerFactory logFactory)
		{
			PlaceService = placeService;
			Logger = logFactory.CreateLogger<AppointmentController>();
		}

		[HttpGet]
		public async Task<IList<PlaceViewModel>> GetPlaces()
		{
			return await PlaceService.GetPlaces();
		}

		[HttpPost]
		public async Task<ActionResult> PostPlace([FromBody] PlaceViewModel placeViewModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			try
			{
				Logger.LogInformation("Log message in the PostPlace() method");
				await PlaceService.InsertPlace(placeViewModel);
				return Created("", null);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error creating new place record");
			}
		}

	}
}
