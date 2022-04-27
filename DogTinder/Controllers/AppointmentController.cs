using AutoMapper;
using DogTinder.Services;
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
		public IList<AppointmentViewModel> Get()
		{
			return AppointmentService.GetAppointments().ToList();
		}
	}
}
