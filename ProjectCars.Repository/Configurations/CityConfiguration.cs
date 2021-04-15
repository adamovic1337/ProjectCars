using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(60).IsRequired();

            builder.HasMany(c => c.CarServices)
                   .WithOne(cs => cs.City)
                   .HasForeignKey(sr => sr.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Users)
                   .WithOne(u => u.City)
                   .HasForeignKey(u => u.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}