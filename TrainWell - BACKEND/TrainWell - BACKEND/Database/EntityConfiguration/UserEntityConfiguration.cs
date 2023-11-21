using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainWell___BACKEND.Models.User;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.Property(c => c.Username).IsRequired(true);
            builder.Property(c => c.Password).IsRequired(true);
            builder.Property(c => c.Email).IsRequired(true);
            builder.Property(c => c.Phone).IsRequired(false);

            builder.HasOne(u => u.UserInfo)
                .WithOne(e => e.User)
                .HasForeignKey<UserInfo>(e => e.UserId)
                .IsRequired(false);
        }
    }
}

