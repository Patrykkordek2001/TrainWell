using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.ExerciseWorkout)
                .WithOne(w => w.Exercise);
        }
    }
}
