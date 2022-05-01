﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DogTinder.EFDataAccessLibrary.Models;

namespace DogTinder.Repository.IRepositories
{
	public interface IAppointmentRepository : IGenericRepository<Appointment>
	{
		Task<IEnumerable<Appointment>> GetAll();
		void Insert(Appointment owner, int dogId, int placeId);
	}
}
