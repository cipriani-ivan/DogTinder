using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace DogTinder.Repository.Repositories
{
	public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
	{

		private readonly DogTinderContext Context;
		private readonly ILogger Logger;

		public AppointmentRepository(DogTinderContext context, ILoggerFactory logFactory) : base(context)
		{
			Context = context;
			Logger = logFactory.CreateLogger<AppointmentRepository>();
		}

		public async Task<IEnumerable<Appointment>> GetAll()
		{
			return await Context.Appointments.Include(a => a.Place).Include(a => a.Dogs).ThenInclude(a => a.Owner).ToListAsync();
		}

		public void Insert(Appointment appointment, int dogId, int placeId)
		{
			var app = Context.Appointments.Add(appointment);
			try
			{
				var dog = Context.Dogs.First(x => x.DogId == dogId);
				var place = Context.Places.First(x => x.PlaceId == placeId);
				app.Entity.Dogs = new List<Dog>() {dog};
				app.Entity.Place = place;
			}
			catch
			{
				Logger.LogInformation($"Log message in the Insert() method dogId = {dogId} or placeId = {placeId} is not a valid id");
				throw;
			}
		}

	}
}

