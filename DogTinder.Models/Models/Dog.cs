using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.Models
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
		
		public int OwnerId { get; set; }
		public Owner Owner { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
	}
}
