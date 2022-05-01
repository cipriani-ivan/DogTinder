using System.Collections.Generic;
using System.Threading.Tasks;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IOwnerService
	{
		Task<IList<OwnerViewModel>> GetOwners();
		Task InsertOwner(OwnerViewModel ownerViewmodel);
	}
}