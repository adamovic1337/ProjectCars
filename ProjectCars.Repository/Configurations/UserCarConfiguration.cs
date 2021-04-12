using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class UserCarConfiguration : IEntityTypeConfiguration<UserCar>
    {
        public void Configure(EntityTypeBuilder<UserCar> builder)
        {
            builder.HasMany(uc => uc.ServiceRequests)
                   .WithOne(sr => sr.UserCars)
                   .HasForeignKey(sr => sr.UserCarId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}