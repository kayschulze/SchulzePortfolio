using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchulzePortfolio.Models
{
	public class SchulzePortfolioDbContext : DbContext
	{

		public SchulzePortfolioDbContext() { }

		public DbSet<GitRepo> GitRepos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
				.UseMySql(@"Server=localhost;Port=8889;database=schulzeportfolio;uid=root;pwd=root;");

		public SchulzePortfolioDbContext(DbContextOptions<SchulzePortfolioDbContext> options)
				: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

	}
}
