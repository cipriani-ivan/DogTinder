using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using DogTinder.Services.IService;
using DogTinder.ViewModels;

namespace DogTinder.Services.Service
{
	public class PlaceService : IPlaceService
	{
		private IPlaceRepository PlaceRepository { get; }
		private readonly IMapper Mapper;

		public PlaceService(IPlaceRepository placeRepository, IMapper mapper)
		{
			PlaceRepository = placeRepository;
			Mapper = mapper;
		}

		public async Task<IList<PlaceViewModel>> GetPlaces()
		{
			var places = await PlaceRepository.GetAllAsync();
			return Mapper.Map<List<PlaceViewModel>>(places);
		}

		public async Task InsertPlace(PlaceViewModel placeViewmodel)
		{
			var place = Mapper.Map<Place>(placeViewmodel);
			PlaceRepository.Insert(place);
			await PlaceRepository.SaveAsync();
		}
	}
}