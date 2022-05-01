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

		public async Task InsertAppointment(PostAppointment appointmentViewModel)
		{
			var appointment = new Appointment
			{
				Time = appointmentViewModel.Time,
			};

			AppointmentRepository.Insert(appointment, appointmentViewModel.DogId, appointmentViewModel.PlaceId);

			await AppointmentRepository.Save();
		}
	}
}
