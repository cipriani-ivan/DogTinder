using DogTinder.Models;
using System.Collections.Generic;

namespace DogTinder.Repository
{
	public interface IAppointmentRepository
	{
		IEnumerable<Appointment> GetAllAppointments();
	}
}
