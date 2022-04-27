using DogTinder.IRepository;
using DogTinder.IServices;
using DogTinder.Models.DataAccess;
using DogTinder.Repository;
using DogTinder.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DogTinder
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "app-client/dist";
			});

			// make automatic for all repository and service
			services.AddScoped<IAppointmentRepository, AppointmentRepository>();
			services.AddScoped<IAppointmentService, AppointmentService>();
			services.AddScoped<IPlaceRepository, PlaceRepository>();
			services.AddScoped<IPlaceService, PlaceService>();
			services.AddScoped<IDogRepository,DogRepository>();
			services.AddScoped<IDogService, DogService>();
			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IOwnerService, OwnerService>();
			services.AddDbContext<DogTinderContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Default"));
			});
			services.AddAutoMapper(typeof(Startup));
			services.AddSwaggerGen();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "app-client";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
