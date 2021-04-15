using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(s => s.ServiceRequests)
                   .WithOne(sr => sr.Status)
                   .HasForeignKey(sr => sr.StatusId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}