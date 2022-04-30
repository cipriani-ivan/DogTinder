using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using DogTinder.Services.IService;
using DogTinder.ViewModels;

namespace DogTinder.Services.Service
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
			var dogs = DogRepository.GetAll(includeProperties: "Owner").ToList();
			return Mapper.Map<List<DogViewModel>>(dogs);
		}

		public void InsertDog(DogViewModel dogViewmodel)
		{
			var dog = Mapper.Map<Dog>(dogViewmodel);
			DogRepository.Insert(dog);
			DogRepository.Save();
		}
	}
}