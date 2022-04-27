using System.Collections.Generic;

namespace DogTinder.ViewModels
{
	public class OwnerViewModel
	{
		public int OwnerId { get; set; }
		public string Name { get; set; }

		public List<DogViewModel> Dogs { get; set; }
	}
}
