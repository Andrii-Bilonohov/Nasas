using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nasas.Domain.Models;
using Nasas.Infrastructure.Configurations;

namespace Nasas.Infrastructure.Data
{
    public class NasasDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connection);
        }


        public DbSet<Scientist> Scientists { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScientistConfiguration());
            modelBuilder.ApplyConfiguration(new PlanetConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
        }
    }
}
