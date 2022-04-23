using DogTinder.Models;
using System.Collections.Generic;

namespace DogTinder.Services
{
	public interface IAppointmentService
	{
		IList<AppointmentModel> GetAppointments();
	}
}
