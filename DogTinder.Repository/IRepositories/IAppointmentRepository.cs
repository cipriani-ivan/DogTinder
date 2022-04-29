using System.Collections.Generic;
using DogTinder.EFDataAccessLibrary.Models;

namespace DogTinder.Repository.IRepositories
{
	public interface IAppointmentRepository
	{
		IEnumerable<Appointment> GetAll();
		void Insert(Appointment owner, int dogId, int placeId);
		void Save();
	}
}
