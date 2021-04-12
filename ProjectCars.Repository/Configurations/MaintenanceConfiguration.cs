using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.Property(m => m.Repairs).HasColumnType("text").IsRequired();
            builder.Property(m => m.Mileage).IsRequired();
            builder.Property(m => m.RepairDate).IsRequired();
        }
    }
}