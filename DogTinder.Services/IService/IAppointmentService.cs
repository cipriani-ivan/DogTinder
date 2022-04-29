using System.Collections.Generic;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IAppointmentService
	{
		IList<AppointmentViewModel> GetAppointments();
		void InsertAppointment(PostAppointment appointmentViewModel);
	}
}
