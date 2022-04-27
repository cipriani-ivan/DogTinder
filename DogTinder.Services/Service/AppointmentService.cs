using AutoMapper;
using DogTinder.Models;
using DogTinder.Repository;
using DogTinder.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DogTinder.Services
{
	public class AppointmentService: IAppointmentService
	{
		private IAppointmentRepository AppointmentRepository { get; }
		private readonly IMapper Mapper;

		public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
		{
			AppointmentRepository = appointmentRepository;
			Mapper = mapper;
		}

		public IList<AppointmentViewModel> GetAppointments()
		{
			var appointments = AppointmentRepository.GetAllAppointments().ToList();
			return Mapper.Map<List<AppointmentViewModel>>(appointments);
		}
	}
}
