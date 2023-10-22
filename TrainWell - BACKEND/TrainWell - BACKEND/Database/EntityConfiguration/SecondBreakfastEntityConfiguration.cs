using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class SecondBreakfastEntityConfiguration : IEntityTypeConfiguration<SecondBreakfast>
    {
        public void Configure(EntityTypeBuilder<SecondBreakfast> builder)
        {
            builder.ToTable("SecondBreakfasts");
            builder.HasKey(e => e.Id);


            builder.Property(c => c.Date).IsRequired(true);


            builder.HasMany(e => e.Products)
               .WithOne(es => es.SecondBreakfast)
               .HasForeignKey(e => e.SecondBreakfastId)
               .IsRequired(false);
        }
    }
}