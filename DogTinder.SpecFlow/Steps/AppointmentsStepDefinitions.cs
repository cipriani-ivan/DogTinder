using DogTinder.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DogTinder.SpecFlow.Steps
{
	[Binding]
	public sealed class AppointmentsStepDefinitions
	{
		private readonly ScenarioContext Context;
		private readonly WebApplicationFactory<Startup> Factory;

		public AppointmentsStepDefinitions(ScenarioContext context, WebApplicationFactory<Startup> factory)
		{
			Context = context;
			Factory = factory;
		}

		[Given("get all the appointments")]
		public async Task GetAllAppointment()
		{
			var client = Factory.CreateClient();
			var response = await client.GetAsync("/Appointment").ConfigureAwait(false);

			try
			{
				Context.Set(response.StatusCode, "ResponseStatusCode");
				var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				var appointmentViewModel = JsonSerializer.Deserialize<List<AppointmentViewModel>>(responseBody);
				Context.Set(appointmentViewModel.Count, "AppointmentViewModelCount");
			}
			finally{ }
		}

		[Then("check if appointments number is bigger of (.*) and the status fo the response is (.*)")]
		public void CheckNumberAppointments(int appointmentsCount, int statusCode)
		{

			((int)Context.Get<HttpStatusCode>("ResponseStatusCode")).Should().Be(statusCode);
			Context.Get<int>("AppointmentViewModelCount").Should().BeGreaterThan(appointmentsCount);
		}

	}
}
