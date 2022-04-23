using System;
using System.Collections.Generic;
using System.Text;

namespace DogTinder.Services
{
	public class AppointmentModel
	{
		public int AppointmentId { get; set; }
		public DateTime Time { get; set; }
		public string Place { get; set; }
		public List<string> Breed { get; set; }

	}

}
