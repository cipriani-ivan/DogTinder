using AutoMapper;
using DogTinder.Models;
using DogTinder.Repository;
using DogTinder.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DogTinder.xUnitTest
{
	public class AppointmentUnitTest
	{

		private readonly AppointmentService appointmentService;
		private static IMapper Mapper;

		public AppointmentUnitTest()
		{
			// Arrage
			var config = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AppointmentProfile());
			});

			Mapper = new Mapper(config);

			var appointmentsData = new List<Appointment>() {

				new Appointment{
					AppointmentId = 1,
					Time = DateTime.Now,
					Place = new Place
					{
						PlaceId = 1,
						Adress = "Ockenburg"
					},
					Dogs = new List<Dog>()
					{
						new Dog()
						{
							DogId = 1,
							Name = "Diablolik",
							Breed = "German Shorthair Pointer"
						},                      
						new Dog()
						{
							DogId = 2,
							Name = "Adrian",
							Breed = "Main Coon"
						},
					}
				},
				new Appointment{ 
					AppointmentId = 2,
					Time = DateTime.Now,
					Place = new Place
					{
						PlaceId = 1,
						Adress = "Ockenburg"
					},
					Dogs = new List<Dog>()
					{
						new Dog()
						{
							DogId = 1,
							Name = "Diablolik",
							Breed = "German Shorthair Pointer"
						},                     
						new Dog()
						{
							DogId = 2,
							Name = "Adrian",
							Breed = "Main Coon"
						},
						new Dog()
						{				
							DogId = 3,
							Name = "Adrian",
							Breed = "Main Coon"
						},
					}
				}
			 };

			var appointmentRepositoryMock = new Mock<IAppointmentRepository>();
			appointmentRepositoryMock.Setup(x => x.GetAllAppointments()).Returns(appointmentsData);
			appointmentService = new AppointmentService(appointmentRepositoryMock.Object, Mapper);
		}

		[Fact]
		public void AppointmentsGetAllTestMapping()
		{
			// Act
			var appointmentViewModel = appointmentService.GetAppointments();

			// Assert
			Assert.Equal(2, appointmentViewModel.Count);
			Assert.Equal(3, appointmentViewModel[1].Dogs.Count);
			Assert.Equal("Ockenburg", appointmentViewModel[1].Place);
		}

	}
}
