using DogTinder.Models;
using DogTinder.Repository;
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

		public IList<AppointmentModel> GetAppointments()
		{

			var test = AppointmentRepository.GetAllAppointments().ToList();
			List<AppointmentModel> appointmentModels = new List<AppointmentModel>();

			test.ForEach(b => {
				appointmentModels.Add(new AppointmentModel
				{
					AppointmentId = b.AppointmentId,
					Time = b.Time,
					Place = b.Place.Adress,
					Breed = b.Dogs.Select(c => c.Breed).ToList()
				});
				}
			);
			return appointmentModels;
		}
	}
}
