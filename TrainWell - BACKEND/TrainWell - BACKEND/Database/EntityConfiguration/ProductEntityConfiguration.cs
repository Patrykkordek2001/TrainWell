using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainWell___BACKEND.Models.Diet
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products"); 

            builder.HasKey(e => e.Id); 

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Calories).IsRequired();
            builder.Property(e => e.Fat);
            builder.Property(e => e.StaruratedFat);
            builder.Property(e => e.Carbohydrates);
            builder.Property(e => e.Sugars);
            builder.Property(e => e.Fiber);
            builder.Property(e => e.Proteins);
            builder.Property(e => e.Salt);

            builder.HasOne(e => e.Dinner)
                .WithMany(d => d.Products)
                .HasForeignKey(e => e.DinnerId)
                .IsRequired(false);

            builder.HasOne(e => e.Lunch)
                .WithMany(l => l.Products)
                .HasForeignKey(e => e.LunchId)
                .IsRequired(false);

            builder.HasOne(e => e.Breakfast)
                .WithMany(b => b.Products)
                .HasForeignKey(e => e.BreakfastId)
                .IsRequired(false);

            builder.HasOne(e => e.Snack)
                .WithMany(s => s.Products)
                .HasForeignKey(e => e.SnackId)
                .IsRequired(false);

            builder.HasOne(e => e.SecondBreakfast)
                .WithMany(sb => sb.Products)
                .HasForeignKey(e => e.SecondBreakfastId)
                .IsRequired(false);
        }
    }
}
