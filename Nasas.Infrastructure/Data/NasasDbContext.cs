using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nasas.Domain.Models;
using Nasas.Infrastructure.Configurations;

namespace Nasas.Infrastructure.Data
{
    public class NasasDbContext : DbContext
    {
        public NasasDbContext(DbContextOptions<NasasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Scientist> Scientists { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScientistConfiguration());
            modelBuilder.ApplyConfiguration(new PlanetConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
        }
    }
}
