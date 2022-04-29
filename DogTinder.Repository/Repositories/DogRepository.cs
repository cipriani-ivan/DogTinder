using System;
using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DogTinder.Repository.Repositories
{
	public class DogRepository : GenericRepository<Dog>, IDogRepository
	{
		public DogRepository(DogTinderContext context) : base(context)
		{
		}
	}
}