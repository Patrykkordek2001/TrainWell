using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Models.Workouts;

namespace TrainWell___BACKEND.Database.EntityConfiguration
{
    public class MeasurementEntityConfiguration : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Measurements");
            builder.HasKey(e => e.Id);
            builder.Property(c => c.Date).IsRequired(true);
            builder.Property(c => c.Weight).IsRequired(true);
            builder.Property(c => c.Shoulders).IsRequired(false); 
            builder.Property(c => c.Chest).IsRequired(false); 
            builder.Property(c => c.Waist).IsRequired(false); 
            builder.Property(c => c.Arm).IsRequired(false); 
            builder.Property(c => c.Thigh).IsRequired(false); 
            builder.Property(c => c.Hips).IsRequired(false); 
        }
    }
}
