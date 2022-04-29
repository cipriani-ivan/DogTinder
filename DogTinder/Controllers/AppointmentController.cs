using DogTinder.Services.IService;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentService AppointmentService;

		public AppointmentController(IAppointmentService appointmentService)
		{
			AppointmentService = appointmentService;
	
		}

		[HttpGet]
		public IList<AppointmentViewModel> GetAppointments()
		{
			return AppointmentService.GetAppointments().ToList();
		}

		[HttpPost]
		public void PostAppointment([FromBody] PostAppointment postAppointment)
		{
			AppointmentService.InsertAppointment(postAppointment);
		}
	}
}
