using DogTinder.IServices;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DogController : ControllerBase
	{
		private readonly IDogService DogService;


		public DogController(IDogService ownerService)
		{
			DogService = ownerService;
		}

		[HttpGet]
		public IList<DogViewModel> GetDogs()
		{
			var test = DogService.GetDogs();
			return DogService.GetDogs();
		}

		[HttpPost]
		public void PostDog([FromBody] DogViewModel dogViewModel)
		{
			DogService.InsertDog(dogViewModel);
		}

	}
}
