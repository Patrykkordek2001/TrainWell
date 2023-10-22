using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class BreakfastEntityConfiguration : IEntityTypeConfiguration<Breakfast>
    {
        public void Configure(EntityTypeBuilder<Breakfast> builder)
        {
            builder.ToTable("Breakfasts");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Date).IsRequired(true);


            builder.HasMany(e => e.Products)
                .WithOne(es => es.Breakfast)
                .HasForeignKey(e => e.BreakfastId)
                .IsRequired(false);
        }
    }    
}
