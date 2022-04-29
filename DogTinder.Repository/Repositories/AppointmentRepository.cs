using System;
using System.Collections.Generic;
using System.Linq;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DogTinder.Repository.Repositories
{
	public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
	{

		private readonly DogTinderContext Context;

		public AppointmentRepository(DogTinderContext context) : base(context)
		{
			Context = context;
		}

		public IEnumerable<Appointment> GetAll()
		{
			return Context.Appointments.Include(a => a.Place).Include(a => a.Dogs).ThenInclude(a => a.Owner);
		}

		public void Insert(Appointment appointment, int dogId, int placeId)
		{
			var app = Context.Appointments.Add(appointment);
			var dog = Context.Dogs.First(x => x.DogId == dogId);
			var place = Context.Places.First(x => x.PlaceId == placeId);
			app.Entity.Dogs = new List<Dog>(){ dog };
			app.Entity.Place = place;
		}

	}
}

