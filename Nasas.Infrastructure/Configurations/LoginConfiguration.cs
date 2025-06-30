using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nasas.Domain.Models;

namespace Nasas.Infrastructure.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasOne(l => l.User)
                .WithOne(u => u.Login)
                .HasForeignKey<Login>(l => l.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
