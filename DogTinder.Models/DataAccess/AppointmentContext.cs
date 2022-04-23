﻿using Microsoft.EntityFrameworkCore;

namespace DogTinder.Models.DataAccess
{
	public class AppointmentContext : DbContext
	{
		public AppointmentContext(DbContextOptions options) : base(options) { }
	    public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Dog> Dogs { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<Place> Places { get; set; }
	}
}
