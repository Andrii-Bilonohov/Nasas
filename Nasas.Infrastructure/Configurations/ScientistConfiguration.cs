using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nasas.Domain.Models;

namespace Nasas.Infrastructure.Configurations
{
    public class ScientistConfiguration : IEntityTypeConfiguration<Scientist>
    {
        public void Configure(EntityTypeBuilder<Scientist> builder)
        {
            builder.HasMany(s => s.Planets)
                .WithOne(p => p.Scientist)
                .HasForeignKey(p => p.ScientistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
