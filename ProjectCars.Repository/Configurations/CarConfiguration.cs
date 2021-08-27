using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Vin).HasMaxLength(17).IsRequired();
            builder.Property(c => c.FirstRegistration).IsRequired();
            builder.Property(c => c.Mileage).IsRequired();

            builder.HasMany(c => c.UserCars)
                   .WithOne(uc => uc.Car)
                   .HasForeignKey(uc => uc.CarId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Maintenance)
                   .WithOne(m => m.Car)
                   .HasForeignKey(m => m.CarId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.ServiceRequests)
                   .WithOne(sr =>sr.Car)
                   .HasForeignKey(sr => sr.CarId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}