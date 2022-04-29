using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogTinder.Services.IService;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OwnerController : ControllerBase
	{
		private readonly IOwnerService OwnerService;

		public OwnerController(IOwnerService ownerService)
		{
			OwnerService = ownerService;
		}

		[HttpGet]
		public IList<OwnerViewModel> GetOwners()
		{
			return OwnerService.GetOwners();
		}

		[HttpPost]
		public void PostOwners([FromBody] OwnerViewModel ownerViewModel)
		{
			OwnerService.InsertOwner(ownerViewModel);
		}
		
	}
}
