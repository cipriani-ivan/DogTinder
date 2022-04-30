using System.ComponentModel.DataAnnotations;

namespace DogTinder.EFDataAccessLibrary.Models
{
	public class Place
	{
		public int PlaceId { get; set; }
		[Required]
		[MaxLength(200)]
		public string Address { get; set; }

	}
}
