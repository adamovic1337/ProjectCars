using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(c => c.Vin).IsUnique();
            builder.Property(c => c.Vin).HasMaxLength(17).IsRequired();
            builder.Property(c => c.FirstRegistration).IsRequired();
            builder.Property(c => c.Mileage).IsRequired();

            builder.HasMany(c => c.CarUsers)
                   .WithOne(cu => cu.Car)
                   .HasForeignKey(cu => cu.CarId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Maintenance)
                   .WithOne(m => m.Car)
                   .HasForeignKey(m => m.CarId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}