using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.EFDataAccessLibrary.Models
{
	public class Dog
	{
		public int DogId { get; set; }
		[Required]
		[MaxLength(200)]
		public string Name { get; set; }
		[Required]
		[MaxLength(200)]
		public string Breed { get; set; }	
		
		public Owner Owner { get; set; }

		[Required]
		public ICollection<Appointment> Appointments { get; set; }
	}
}
