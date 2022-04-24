using DogTinder.Models;
using DogTinder.ViewModels;
using System.Collections.Generic;

namespace DogTinder.Services
{
	public interface IAppointmentService
	{
		IList<Appointment> GetAppointments();
	}
}
