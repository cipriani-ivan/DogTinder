using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public async Task<IList<AppointmentViewModel>> GetAppointments()
		{
			var appointments = await AppointmentRepository.GetAll();
			return Mapper.Map<List<AppointmentViewModel>>(appointments);
		}

		public async Task InsertAppointment(PostUpdateAppointment appointmentViewModel)
		{
			var appointment = new Appointment
			{
				Time = appointmentViewModel.Time,
				Place = new Place() { PlaceId = appointmentViewModel.PlaceId },
				Dog = new Dog() { DogId = appointmentViewModel.DogId } 
			};

			AppointmentRepository.Insert(appointment);

			await AppointmentRepository.SaveAsync();
		}

		public async Task UpdateAppointment(PostUpdateAppointment appointmentViewModel)
		{
			// TODO: move to profile
			var appointment = new Appointment
			{
				AppointmentId = appointmentViewModel.AppointmentId,
				Time = appointmentViewModel.Time,
				Place = new Place(){PlaceId = appointmentViewModel.PlaceId},
				Dog = new Dog(){DogId = appointmentViewModel.DogId}
			};

			AppointmentRepository.Update(appointment);

			await AppointmentRepository.SaveAsync();
		}

		public async Task DeleteAppointment(int appointmentId)
		{
			AppointmentRepository.Delete(appointmentId);

			await AppointmentRepository.SaveAsync();
		}
	}
}
