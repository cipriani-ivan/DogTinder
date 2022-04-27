using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogTinder.Models
{
	public class Owner
	{
		public int OwnerId { get; set; }
		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		public List<Dog> Dogs { get; set; }
	}
}
