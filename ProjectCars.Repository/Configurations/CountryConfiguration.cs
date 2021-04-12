using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Name).HasMaxLength(60).IsRequired();

            builder.HasMany(c => c.Cities)
                   .WithOne(ci => ci.Country)
                   .HasForeignKey(ci => ci.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Manufacturers)
                   .WithOne(m => m.Country)
                   .HasForeignKey(m => m.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}