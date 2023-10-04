using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.NumberOfRepeats)
                .IsRequired();

            builder.Property(c => c.NumberOfSeries)
                .IsRequired();

            builder.Property(c => c.Weight)
                .IsRequired();

            builder.HasOne(e => e.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(e => e.WorkoutId)
                .IsRequired();
        }
    }
}
