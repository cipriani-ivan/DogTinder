using System;
using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;

namespace DogTinder.Repository.Repositories
{
	public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
	{
		public OwnerRepository(DogTinderContext context) : base(context)
		{
		}
	}
}