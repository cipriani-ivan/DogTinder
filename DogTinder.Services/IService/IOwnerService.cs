using System.Collections.Generic;
using DogTinder.ViewModels;

namespace DogTinder.Services.IService
{
	public interface IOwnerService
	{
		IList<OwnerViewModel> GetOwners();
		void InsertOwner(OwnerViewModel ownerViewmodel);
	}
}