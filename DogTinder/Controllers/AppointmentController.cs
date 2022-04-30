using DogTinder.Services.IService;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DogTinder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentService AppointmentService;
		private readonly ILogger Logger;

		public AppointmentController(IAppointmentService appointmentService, ILoggerFactory logFactory)
		{
			AppointmentService = appointmentService;
			Logger = logFactory.CreateLogger<AppointmentController>();

		}

		[HttpGet]
		public IList<AppointmentViewModel> GetAppointments()
		{
			Logger.LogInformation("Log message in the GetAppointments() method");
			return AppointmentService.GetAppointments().ToList();
		}

		[HttpPost]
		public void PostAppointment([FromBody] PostAppointment postAppointment)
		{
			Logger.LogInformation("Log message in the PostAppointment() method");
			AppointmentService.InsertAppointment(postAppointment);
		}
	}
}
