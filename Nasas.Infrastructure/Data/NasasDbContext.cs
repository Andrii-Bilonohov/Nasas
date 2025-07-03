using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScientistConfiguration());
            modelBuilder.ApplyConfiguration(new PlanetConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
        }
    }
}
