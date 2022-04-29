using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using DogTinder.Services.IService;
using DogTinder.ViewModels;

namespace DogTinder.Services.Service
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

		public void InsertAppointment(PostAppointment appointmentViewModel)
		{
			var appointment = new Appointment
			{
				Time = appointmentViewModel.Time,
			};

			AppointmentRepository.Insert(appointment, appointmentViewModel.DogId, appointmentViewModel.PlaceId);

			AppointmentRepository.Save();
		}
	}
}
