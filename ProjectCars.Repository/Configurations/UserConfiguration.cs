using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCars.Model.Entities;

namespace ProjectCars.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(30).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(254).IsRequired();

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