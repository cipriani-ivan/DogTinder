using AutoMapper;
using DogTinder.IRepository;
using DogTinder.IServices;
using DogTinder.Models;
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
			var appointments = AppointmentRepository.GetAll().ToList();
			return Mapper.Map<List<AppointmentViewModel>>(appointments);
		}

		public void InsertAppointment(AppointmentViewModel appointmentViewModel)
		{
			var appointment = Mapper.Map<Appointment>(appointmentViewModel);
			AppointmentRepository.Insert(appointment);
		}
	}
}
