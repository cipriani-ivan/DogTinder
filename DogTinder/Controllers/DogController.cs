using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DogTinder.Services.IService;

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
		public async Task<IList<DogViewModel>> GetDogs()
		{
			return await DogService.GetDogs();
		}

		[HttpPost]
		public async Task PostDog([FromBody] DogViewModel dogViewModel)
		{
			await DogService.InsertDog(dogViewModel);
		}

	}
}
