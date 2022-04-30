using System.Linq;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.ViewModels;

namespace DogTinder.Profile
{
	public class DogTinderProfile: AutoMapper.Profile
	{
		public DogTinderProfile()
		{
			CreateMap<Appointment, AppointmentViewModel>()
				.ForMember(dest =>
				dest.Place,
				opt => opt.MapFrom(scr => scr.Place.Address)).
				ForMember(dest =>
				dest.Dogs,
				opt => opt.MapFrom(scr => 
					scr.Dogs.Select(c => new DogViewModel() { Name = c.Name, Breed = c.Breed, Owner = new OwnerViewModel(){OwnerId = c.Owner.OwnerId, Name = c.Owner.Name }}).ToList() 
				));
			CreateMap<AppointmentViewModel, Appointment>();
			CreateMap<Owner, OwnerViewModel>();
			CreateMap<OwnerViewModel, Owner>();
			CreateMap<Place, PlaceViewModel>();
			CreateMap<PlaceViewModel, Place>();
			CreateMap<Dog, DogViewModel>();
			CreateMap<DogViewModel, Dog>();
		}			
	}	
}
