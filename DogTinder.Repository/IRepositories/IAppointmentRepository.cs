﻿using DogTinder.Models;
using System.Collections.Generic;

namespace DogTinder.IRepository
{
	public interface IAppointmentRepository
	{
		IEnumerable<Appointment> GetAll();
		void Insert(Appointment owner);
		void Save();
	}
}
