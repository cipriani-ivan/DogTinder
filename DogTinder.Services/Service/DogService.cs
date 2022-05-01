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
	public class DogService : IDogService
	{
		private IDogRepository DogRepository { get; }
		private readonly IMapper Mapper;

		public DogService(IDogRepository dogRepository, IMapper mapper)
		{
			DogRepository = dogRepository;
			Mapper = mapper;
		}

		public async Task<IList<DogViewModel>> GetDogs()
		{
			var dogs = await DogRepository.GetAll(includeProperties: "Owner");
			return Mapper.Map<List<DogViewModel>>(dogs);
		}

		public async Task InsertDog(DogViewModel dogViewmodel)
		{
			var dog = Mapper.Map<Dog>(dogViewmodel);
			DogRepository.Insert(dog, dogViewmodel.OwnerId);
			await DogRepository.Save();
		}
	}
}