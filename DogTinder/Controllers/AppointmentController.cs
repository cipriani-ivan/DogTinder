using DogTinder.Services.IService;
using DogTinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
		public async Task<List<AppointmentViewModel>> GetAppointments()
		{
			Logger.LogInformation("Log message in the GetAppointments() method");
			return (await AppointmentService.GetAppointments()).ToList();
		}

		/// <summary>
		/// Creates an appointment.
		/// </summary>
		/// <param name="postAppointment"></param>
		/// <returns>A newly created appointment</returns>
		/// <remarks>
		/// Sample request:
		///     POST /Appointment
		///     {
		///        "time": "2022-05-20",
		///        "placeId": 1,
		///        "dogId": 1
		///     }
		///
		/// </remarks>
		/// <response code="201">Return void</response>
		/// <response code="400">If the item is null</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Produces("application/json")]
		public async Task<HttpResponseMessage> PostAppointment([FromBody] PostAppointment postAppointment)
		{
			if (!ModelState.IsValid) return new HttpResponseMessage(HttpStatusCode.BadRequest);
			Logger.LogInformation("Log message in the PostAppointment() method");
			await AppointmentService.InsertAppointment(postAppointment);
			return new HttpResponseMessage(HttpStatusCode.Created);
		}
	}
}
