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
            builder.HasOne(e => e.ProductInMeal)
                .WithOne(d => d.Product)
                .IsRequired(true);

        }
    }
}
