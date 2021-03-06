using System;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.ViewModels
{
	public class PostUpdateAppointment
	{
		public int AppointmentId { get; set; }
		[Required]
		public DateTime Time { get; set; }
		[Required]
		public int PlaceId { get; set; }
		[Required]
		public int DogId{ get; set; }
	}

}
