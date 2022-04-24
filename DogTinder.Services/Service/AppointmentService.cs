using DogTinder.Models;
using DogTinder.Repository;
using DogTinder.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DogTinder.Services
{
	public class AppointmentService: IAppointmentService
	{
		public AppointmentService(IAppointmentRepository appointmentRepository)
		{
			AppointmentRepository = appointmentRepository;
		}

		private IAppointmentRepository AppointmentRepository { get; }

		public IList<AppointmentViewModel> GetAppointments()
		{

			var test = AppointmentRepository.GetAllAppointments().ToList();
			List<AppointmentViewModel> appointmentModels = new List<AppointmentViewModel>();

			test.ForEach(b => {
				appointmentModels.Add(new AppointmentViewModel
				{
					AppointmentId = b.AppointmentId,
					Time = b.Time,
					Place = b.Place.Adress,
					Dogs = b.Dogs.Select(c => new DogViewModel() { Name = c.Name, Breed = c.Breed }).ToList()
				});
				}
			);
			return appointmentModels;
		}
	}
}
