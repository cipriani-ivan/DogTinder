using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DogTinder.Repository.Repositories
{
	public class DogRepository : GenericRepository<Dog>, IDogRepository
	{
		private readonly DogTinderContext Context;
		private readonly ILogger Logger;

		public DogRepository(DogTinderContext context, ILoggerFactory logFactory) : base(context)
		{
			Context = context;
			Logger = logFactory.CreateLogger<AppointmentRepository>();
		}

		public void Insert(Dog dog, int ownerId)
		{
			var d = Context.Dogs.Add(dog);
			try
			{
				var owner = Context.Owners.First(x => x.OwnerId == ownerId);
				d.Entity.Owner = owner;
			}
			catch
			{
				Logger.LogInformation($"Log message in the Insert() method OwnerId = {ownerId} is not a valid id");
				throw;
			}
		}
	}
}