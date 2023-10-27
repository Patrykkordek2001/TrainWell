using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class ProductInMealEntityConfiguration : IEntityTypeConfiguration<ProductInMeal>
    {
        public void Configure(EntityTypeBuilder<ProductInMeal> builder)
        {
            builder.ToTable("ProductsInMeals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Grams).IsRequired(true);

            builder.HasOne(e => e.Product)
                .WithOne(d => d.ProductInMeal)
                .IsRequired(true);
        }
    }
}
