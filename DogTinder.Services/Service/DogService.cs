using AutoMapper;
using DogTinder.IRepository;
using DogTinder.IServices;
using DogTinder.Models;
using DogTinder.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DogTinder.Services
{
	public class DogService : IDogService
	{
		private IDogRepository DogRepository { get; }
		private readonly IMapper Mapper;

		public DogService(IDogRepository dogRepository, IMapper mapper)
		{
			DogRepository = dogRepository;
			Mapper = mapper;
		}

		public IList<DogViewModel> GetDogs()
		{
			var dogs = DogRepository.GetAll().ToList();
			return Mapper.Map<List<DogViewModel>>(dogs);
		}

		public void InsertDog(DogViewModel dogViewmodel)
		{
			var dog = Mapper.Map<Dog>(dogViewmodel);
			DogRepository.Insert(dog);
		}
	}
}