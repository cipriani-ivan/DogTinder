using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using System.Linq;

namespace DogTinder.Repository.Repositories
{
	public class DogRepository : GenericRepository<Dog>, IDogRepository
	{
		private readonly DogTinderContext Context;

		public DogRepository(DogTinderContext context) : base(context)
		{
			Context = context;
		}

		public void Insert(Dog dog, int ownerId)
		{
			var d = Context.Dogs.Add(dog);
			var owner = Context.Owners.First(x => x.OwnerId == ownerId);
			d.Entity.Owner = owner;
		}
	}
}