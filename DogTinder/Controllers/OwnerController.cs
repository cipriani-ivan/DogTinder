using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
		public async Task<HttpResponseMessage> PostOwners([FromBody] OwnerViewModel ownerViewModel)
		{
			if (!ModelState.IsValid) return new HttpResponseMessage(HttpStatusCode.BadRequest);
			await OwnerService.InsertOwner(ownerViewModel);
			return new HttpResponseMessage(HttpStatusCode.Created);
		}
		
	}
}
