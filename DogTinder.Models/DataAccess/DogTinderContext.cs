using DogTinder.EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DogTinder.EFDataAccessLibrary.DataAccess
{
	public class DogTinderContext : DbContext
	{
		public DogTinderContext(DbContextOptions options) : base(options) { }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Dog> Dogs { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<Place> Places { get; set; }
	}
}
