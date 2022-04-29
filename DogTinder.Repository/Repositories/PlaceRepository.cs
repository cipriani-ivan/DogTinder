using DogTinder.EFDataAccessLibrary.DataAccess;
using DogTinder.EFDataAccessLibrary.Models;
using DogTinder.Repository.IRepositories;

namespace DogTinder.Repository.Repositories
{
	public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
	{
		public PlaceRepository(DogTinderContext context) : base(context)
		{
		}
	}
}