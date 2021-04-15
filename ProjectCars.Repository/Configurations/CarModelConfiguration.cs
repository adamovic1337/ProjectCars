using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(m => m.Cars)
                   .WithOne(c => c.Model)
                   .HasForeignKey(c => c.ModelId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}