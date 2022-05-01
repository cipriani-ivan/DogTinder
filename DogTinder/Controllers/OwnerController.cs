using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public async Task<IList<OwnerViewModel>> GetOwners()
		{
			return await OwnerService.GetOwners();
		}

		[HttpPost]
		public async Task PostOwners([FromBody] OwnerViewModel ownerViewModel)
		{
			await OwnerService.InsertOwner(ownerViewModel);
		}
		
	}
}
