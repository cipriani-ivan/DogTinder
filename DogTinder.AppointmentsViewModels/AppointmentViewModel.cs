using System;
using System.Collections;
using System.Collections.Generic;

namespace DogTinder.ViewModels
{
	public class AppointmentViewModel
	{
		public int AppointmentId { get; set; }
		public DateTime Time { get; set; }
		public PlaceViewModel Place { get; set; }
		public DogViewModel Dog { get; set; }
	}

}
