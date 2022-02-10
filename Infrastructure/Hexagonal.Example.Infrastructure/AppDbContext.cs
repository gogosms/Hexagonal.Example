using Hexagonal.Example.Core.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Example.Infrastructure
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Movie> Movies { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
