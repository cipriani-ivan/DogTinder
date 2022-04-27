using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.Models
{
	public class Place
	{
		public int PlaceId { get; set; }
		[Required]
		[MaxLength(200)]
		public string Adress { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
	}
}
