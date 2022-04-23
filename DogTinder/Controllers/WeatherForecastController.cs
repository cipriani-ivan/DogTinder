using DogTinder.Models;
using DogTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IAppointmentService appointmentService;

		public WeatherForecastController(IAppointmentService appointmentService)
		{
			this.appointmentService = appointmentService;
		}

		[HttpGet]
		public IList<AppointmentModel> Get()
		{
			var test = appointmentService.GetAppointments();
			return test;
		}
	}
}
