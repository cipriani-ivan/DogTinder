using DogTinder.IServices;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
		public void PostOwners(OwnerViewModel ownerViewModel)
		{
			OwnerService.InsertOwner(ownerViewModel);
		}
		
	}
}
