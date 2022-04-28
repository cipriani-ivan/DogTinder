using AutoMapper;
using DogTinder.Models;
using DogTinder.ViewModels;
using System.Linq;

namespace DogTinder
{
	public class DogTinderProfile: Profile
	{
		public DogTinderProfile()
		{
			CreateMap<Appointment, AppointmentViewModel>()
				.ForMember(dest =>
				dest.Place,
				opt => opt.MapFrom(scr => scr.Place.Adress)).
				ForMember(dest =>
				dest.Dogs,
				opt => opt.MapFrom(scr => 
					scr.Dogs.Select(c => new DogViewModel() { Name = c.Name, Breed = c.Breed }).ToList() 
				));
			CreateMap<Owner, OwnerViewModel>();
			CreateMap<OwnerViewModel, Owner>();
			CreateMap<Place, PlaceViewModel>();
			CreateMap<Dog, DogViewModel>();
		}			
	}	
}
