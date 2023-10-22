using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class DinnerEntityConfiguration : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            builder.ToTable("Dinners");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Date).IsRequired(true);


            builder.HasMany(e => e.Products)
                .WithOne(es => es.Dinner)
                .HasForeignKey(e => e.DinnerId)
                .IsRequired(false);
        }
    }
}
