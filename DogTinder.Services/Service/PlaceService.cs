﻿using System.Collections.Generic;
using System.Linq;
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

		public IList<PlaceViewModel> GetPlaces()
		{
			var places = PlaceRepository.GetAll().ToList();
			return Mapper.Map<List<PlaceViewModel>>(places);
		}

		public void InsertPlace(PlaceViewModel placeViewmodel)
		{
			var place = Mapper.Map<Place>(placeViewmodel);
			PlaceRepository.Insert(place);
			PlaceRepository.Save();
		}
	}
}