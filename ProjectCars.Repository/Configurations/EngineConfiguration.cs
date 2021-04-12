using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.Property(e => e.CubicCapacity).HasMaxLength(4).IsRequired();
            builder.Property(e => e.Power).HasMaxLength(4).IsRequired();

            builder.HasMany(e => e.Models)
                   .WithOne(m => m.Engine)
                   .HasForeignKey(m => m.EngineId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}