using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.EFDataAccessLibrary.Models
{
	public class Appointment
	{
		public int AppointmentId { get; set; }
		[Required]
		public DateTime Time { get; set; }

		public Place Place { get; set; }

		public ICollection<Dog> Dogs { get; set; }
	}
}
