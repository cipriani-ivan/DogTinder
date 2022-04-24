using DogTinder.Models;
using DogTinder.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DogTinder.Services
{
	public class AppointmentService: IAppointmentService
	{
		private IAppointmentRepository AppointmentRepository { get; }

		public AppointmentService(IAppointmentRepository appointmentRepository)
		{
			AppointmentRepository = appointmentRepository;

		}

		public IList<Appointment> GetAppointments()
		{
			return AppointmentRepository.GetAllAppointments().ToList(); ;
		}
	}
}
