namespace DogTinder.ViewModels
{
	public class DogViewModel
	{
		public string Name { get; set; }
		public string Breed { get; set; }

		public int  OwnerId { get; set; }
		public OwnerViewModel Owner { get; set; }
	}
}
