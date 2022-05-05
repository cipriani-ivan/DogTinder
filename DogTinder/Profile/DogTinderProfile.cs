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
				.ForMember(dest => dest.Place,
					opt => opt.MapFrom(scr => new PlaceViewModel()
					{
						PlaceId = scr.Place.PlaceId, Address = scr.Place.Address
					}))
				.ForMember(dest => dest.Dog,
					opt => opt.MapFrom(scr => new DogViewModel()
						{
							DogId = scr.Dog.DogId, Name = scr.Dog.Name, Breed = scr.Dog.Breed,
							Owner = new OwnerViewModel() {OwnerId = scr.Dog.Owner.OwnerId, Name = scr.Dog.Owner.Name}
						}));
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
