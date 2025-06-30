using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nasas.Domain.Models;

namespace Nasas.Infrastructure.Configurations
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasOne(p => p.Scientist)
                .WithMany(s => s.Planets)
                .HasForeignKey(p => p.ScientistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
