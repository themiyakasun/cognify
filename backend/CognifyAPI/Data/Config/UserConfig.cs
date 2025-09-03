using CognifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognifyAPI.Data.Config
{
    public class UserConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).UseIdentityColumn();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(55);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(55);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(u => u.ProfilePictureUrl).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Bio).HasMaxLength(50);
            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValue(new DateTime()).ValueGeneratedOnAdd();
            builder.Property(u => u.LastLogin).IsRequired().HasDefaultValue(new DateTime()).ValueGeneratedOnAddOrUpdate();
            builder.Property(u => u.Role).IsRequired().HasDefaultValue(UserRoles.Student).ValueGeneratedOnAdd();
            builder.Property(u => u.Status).IsRequired().HasDefaultValue(UserStatus.Inactive).ValueGeneratedOnAdd();
        }
    }
}
