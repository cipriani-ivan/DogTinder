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
		private readonly IAppointmentService appointmentService;
		private readonly IMapper mapper;

		public AppointmentController(IAppointmentService appointmentService, IMapper mapper )
		{
			this.appointmentService = appointmentService;
			this.mapper = mapper;
		}

		[HttpGet]
		public IList<AppointmentViewModel> Get()
		{
			var appointments = appointmentService.GetAppointments().ToList();

			return mapper.Map<List<AppointmentViewModel>>(appointments);
		}
	}
}
