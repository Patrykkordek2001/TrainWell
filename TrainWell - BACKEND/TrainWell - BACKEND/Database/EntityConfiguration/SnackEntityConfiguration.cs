using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class SnackEntityConfiguration : IEntityTypeConfiguration<Snack>
    {
        public void Configure(EntityTypeBuilder<Snack> builder)
        {
            builder.ToTable("Snacks");
            builder.HasKey(e => e.Id);


            builder.Property(c => c.Date).IsRequired(true);


            builder.HasMany(e => e.Products)
               .WithOne(es => es.Snack)
               .HasForeignKey(e => e.SnackId)
               .IsRequired(false);
        }
    }
}

