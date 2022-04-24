using DogTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentService appointmentService;

		public AppointmentController(IAppointmentService appointmentService)
		{
			this.appointmentService = appointmentService;
		}

		[HttpGet]
		public IList<AppointmentViewModel> Get()
		{
			return appointmentService.GetAppointments();
		}
	}
}
