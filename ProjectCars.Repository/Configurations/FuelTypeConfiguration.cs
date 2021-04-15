using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(15).IsRequired();

            builder.HasMany(f => f.Engines)
                   .WithOne(e => e.FuelType)
                   .HasForeignKey(e => e.FuelTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}