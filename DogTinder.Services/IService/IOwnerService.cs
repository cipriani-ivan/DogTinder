using DogTinder.ViewModels;
using System.Collections.Generic;

namespace DogTinder.IServices
{
	public interface IOwnerService
	{
		IList<OwnerViewModel> GetOwners();
		void InsertOwner(OwnerViewModel ownerViewmodel);
	}
}