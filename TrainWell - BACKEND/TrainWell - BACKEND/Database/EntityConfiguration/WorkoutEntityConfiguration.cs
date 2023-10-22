using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workouts");
            builder.HasKey(e => e.Id);


            builder.Property(c => c.Title)
                .IsRequired(true);

            builder.Property(c => c.Date)
                .IsRequired(true);

            builder.HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId).
                IsRequired(false);
        }
    }






}
