using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {   }

		// DbSets

		public DbSet<Products> Products { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(" Server=KHALED_ALTABEY;Database=FurniAppDatabase;Integrated Security=SSPI;TrustServerCertificate=True;")
                        .LogTo(Console.WriteLine, LogLevel.Information);
            }
            base.OnConfiguring(optionsBuilder);
        }

        // Configurations Added using Fluent API in the Configuration Folder In DataAccessLayer 

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelbuilder);
        }
        


    }
}
