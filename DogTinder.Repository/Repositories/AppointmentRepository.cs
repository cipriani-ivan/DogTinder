﻿using DogTinder.IRepository;
using DogTinder.Models;
using DogTinder.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DogTinder.Repository
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly DogTinderContext Context;

		public AppointmentRepository(DogTinderContext context)
		{
			Context = context;
		}

		public IEnumerable<Appointment> GetAll()
		{
			return Context.Appointments.Include(a => a.Place).Include(a => a.Dogs);
		}

		public void Insert(Appointment appointment)
		{
			Context.Appointments.Add(appointment);
		}

		public void Save()
		{
			Context.SaveChanges();
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

