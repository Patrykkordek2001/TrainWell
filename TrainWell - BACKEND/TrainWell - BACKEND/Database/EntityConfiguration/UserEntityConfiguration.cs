using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Username).IsRequired(true);
            builder.Property(c => c.Password).IsRequired(true);
            builder.Property(c => c.Email).IsRequired(true);
            builder.Property(c => c.Phone).IsRequired(true);
        }
    }
}
