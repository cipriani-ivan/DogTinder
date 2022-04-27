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

		// GET: OwnerController/Create
		public IList<DogViewModel> GeDogs()
		{
			return DogService.GetDogs();
		}

		// POST: OwnerController/Create
		[HttpPost]
		public void PostDog(DogViewModel dogViewModel)
		{
			DogService.InsertDog(dogViewModel);
		}

	}
}
