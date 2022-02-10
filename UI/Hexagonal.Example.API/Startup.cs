using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hexagonal.Example.Core.Interfaces;
using Hexagonal.Example.Core.Services.MovieUseCases;
using Hexagonal.Example.Infrastructure;
using Hexagonal.Example.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Example.API
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TestDB"));
			services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

			//Services
			services.AddMediatR(typeof(CreateMovieHandler));

			services.AddMvc(option => option.EnableEndpointRouting = false);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc(builder => {});

			
		}
	}
}
