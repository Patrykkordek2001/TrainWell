using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class ExerciseSetEntityConfiguration : IEntityTypeConfiguration<ExerciseSet>
    {
        public void Configure(EntityTypeBuilder<ExerciseSet> builder)
        {
            builder.ToTable("ExerciseSets");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Weight).IsRequired(false); 
            builder.Property(c => c.Repetitions).IsRequired(true); ;

            builder.HasOne(e => e.Exercise)
                .WithMany(exercise => exercise.ExerciseSets) 
                .HasForeignKey(e => e.ExerciseId)
                .IsRequired(true);
        }
    }

}
