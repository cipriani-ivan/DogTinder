using System.Collections.Generic;
using System.Threading.Tasks;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IAppointmentService
	{
		Task<IList<AppointmentViewModel>> GetAppointments();
		Task InsertAppointment(PostUpdateAppointment appointmentViewModel);
		Task UpdateAppointment(PostUpdateAppointment appointmentViewModel);
		Task DeleteAppointment(int appointmentId);
	}
}
