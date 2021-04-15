using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).HasMaxLength(50);
            builder.Property(user => user.LastName).HasMaxLength(50);
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Username).HasMaxLength(30).IsRequired();
            builder.Property(user => user.Email).HasMaxLength(254).IsRequired();

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