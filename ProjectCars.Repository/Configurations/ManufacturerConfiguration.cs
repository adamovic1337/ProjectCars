using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(m => m.Models)
                   .WithOne(mo => mo.Manufacturer)
                   .HasForeignKey(mo => mo.ManufacturerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}