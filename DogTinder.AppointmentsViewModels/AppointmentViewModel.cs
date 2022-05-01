using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.ViewModels
{
	public class AppointmentViewModel
	{
		public int AppointmentId { get; set; }
		public DateTime Time { get; set; }
		public int PlaceId { get; set; }
		public string Place { get; set; }
		public List<DogViewModel> Dogs { get; set; }
	}

}
