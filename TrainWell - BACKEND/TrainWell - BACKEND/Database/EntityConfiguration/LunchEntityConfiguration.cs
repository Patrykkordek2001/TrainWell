using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class LunchEntityConfiguration : IEntityTypeConfiguration<Lunch>
    {
        public void Configure(EntityTypeBuilder<Lunch> builder)
        {
            builder.ToTable("Lunches");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Date).IsRequired(true);


            builder.HasMany(e => e.Products)
                .WithOne(es => es.Lunch)
                .HasForeignKey(e => e.LunchId)
                .IsRequired(false);
        }
    }
}
