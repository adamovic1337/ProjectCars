using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public  class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(user => user.FirstName).HasMaxLength(50);
            builder.Property(user => user.LastName).HasMaxLength(50);

            builder.HasMany(u => u.UserCars)
                   .WithOne(uc => uc.User)
                   .HasForeignKey(uc => uc.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CarServices)
                .WithOne(cs => cs.User)
                .HasForeignKey(cs => cs.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
