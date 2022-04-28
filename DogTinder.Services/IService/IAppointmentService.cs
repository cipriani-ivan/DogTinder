using DogTinder.ViewModels;
using System.Collections.Generic;

namespace DogTinder.IServices
{
	public interface IAppointmentService
	{
		IList<AppointmentViewModel> GetAppointments();
		void InsertAppointment(AppointmentViewModel appointmentViewModel);
	}
}
