using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class CarServiceConfiguration : IEntityTypeConfiguration<CarService>
    {
        public void Configure(EntityTypeBuilder<CarService> builder)
        {
            builder.Property(cs => cs.Name).HasMaxLength(100).IsRequired();
            builder.Property(cs => cs.Phone).HasMaxLength(20).IsRequired();
            builder.Property(cs => cs.Address).HasMaxLength(100).IsRequired();
            builder.Property(cs => cs.Email).HasMaxLength(254).IsRequired();
            builder.Property(cs => cs.Website);

            builder.HasMany(cs => cs.ServiceRequests)
                   .WithOne(sr => sr.CarService)
                   .HasForeignKey(sr => sr.CarServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(cs => cs.Maintenance)
                   .WithOne(m => m.CarService)
                   .HasForeignKey(m => m.CarServiceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}