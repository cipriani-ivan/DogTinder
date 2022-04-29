using System;
using System.Collections.Generic;

namespace DogTinder.ViewModels
{
	public class AppointmentViewModel
	{
		public int AppointmentId { get; set; }
		public DateTime Time { get; set; }
		public int placeId { get; set; }
		public string Place { get; set; }
		public List<DogViewModel> Dogs { get; set; }
	}

}
