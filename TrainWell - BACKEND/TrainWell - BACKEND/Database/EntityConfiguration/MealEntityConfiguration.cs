using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class MealEntityConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.ToTable("Meals");
            builder.HasKey(e => e.Id);
            builder.Property(m => m.Date).IsRequired(true);
            builder.Property(m => m.MealName).IsRequired(true);

            builder.HasMany(e => e.ProductsInMeal)
                .WithOne(es => es.Meal)
                .HasForeignKey(e => e.MealId)
                .IsRequired(false);
        }
    }
}
