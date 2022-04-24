using DogTinder.ViewModels;
using System;
using System.Collections.Generic;

namespace DogTinder.Services
{
	public class AppointmentViewModel
	{
		public int AppointmentId { get; set; }
		public DateTime Time { get; set; }
		public string Place { get; set; }
		public List<DogViewModel> Dogs { get; set; }
	}

}
