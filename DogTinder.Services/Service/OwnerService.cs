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
	public class OwnerService: IOwnerService
	{
		private IOwnerRepository OwnerRepository { get; }
		private readonly IMapper Mapper;

		public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
		{
			OwnerRepository = ownerRepository;
			Mapper = mapper;
		}

		public async Task<IList<OwnerViewModel>> GetOwners()
		{
			var owners = await OwnerRepository.GetAllAsync();
			return Mapper.Map<List<OwnerViewModel>>(owners);
		}

		public async Task InsertOwner(OwnerViewModel ownerViewmodel)
		{
			var owner = Mapper.Map<Owner>(ownerViewmodel);
			OwnerRepository.Insert(owner);
			await OwnerRepository.SaveAsync();
		}
	}
}
