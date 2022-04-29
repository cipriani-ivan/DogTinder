﻿using System.Collections.Generic;
using System.Linq;
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

		public IList<OwnerViewModel> GetOwners()
		{
			var owners = OwnerRepository.GetAll().ToList();
			return Mapper.Map<List<OwnerViewModel>>(owners);
		}

		public void InsertOwner(OwnerViewModel ownerViewmodel)
		{
			var owner = Mapper.Map<Owner>(ownerViewmodel);
			OwnerRepository.Insert(owner);
			OwnerRepository.Save();
		}
	}
}
