using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class ExerciseWorkoutEntityConfiguration : IEntityTypeConfiguration<ExerciseWorkout>
    {
        public void Configure(EntityTypeBuilder<ExerciseWorkout> builder)
        {
            builder.ToTable("ExerciseWorkouts");
            builder.HasKey(e => e.Id);


            builder.HasOne(ew => ew.Exercise)
                .WithMany(w => w.ExerciseWorkouts)
                .HasForeignKey(e => e.ExerciseId);

            //builder.HasOne(ew => ew.Workout)
            //    .WithMany(w => w.ExerciseWorkouts)
            //    .HasForeignKey(e => e.WorkoutId);
        }
    }
}
