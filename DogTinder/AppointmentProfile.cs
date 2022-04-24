using AutoMapper;
using DogTinder.Models;
using DogTinder.ViewModels;
using System.Linq;

namespace DogTinder
{
	public class AppointmentProfile: Profile
	{
		public AppointmentProfile()
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
			}
	}
}
