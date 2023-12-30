using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainWell___BACKEND.Models.Users;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class UserInfoEntityConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("UserInfos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Weight).IsRequired();
            builder.Property(e => e.Growth).IsRequired();
            builder.Property(e => e.Activity).IsRequired();
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.CaloriesPerDay).IsRequired();
            builder.Property(e => e.FatPerDay).IsRequired();
            builder.Property(e => e.CarbohydratesPerDay).IsRequired();
            builder.Property(e => e.ProteinsPerDay).IsRequired();

            builder.HasOne(e => e.User)
                .WithOne(u => u.UserInfo)
                .HasForeignKey<UserInfo>(e => e.UserId)
                .IsRequired();
        }
    }
}