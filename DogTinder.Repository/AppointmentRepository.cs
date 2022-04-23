using DogTinder.Models;
using DogTinder.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DogTinder.Repository
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly AppointmentContext Context;

		public AppointmentRepository(AppointmentContext context)
		{
			Context = context;
		}

		public IEnumerable<Appointment> GetAllAppointments()
		{
			return Context.Appointments.Include(a => a.Place).Include(a => a.Dogs);
		}
	}
}
