using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models
{
    public class Measurement
    {
        public Measurement()
        {
        }

        public Measurement(double shoulders, double chest, double waist, double arm, double thigh, double hips, double weight, DateTime date)
        {
            Shoulders = shoulders;
            Chest = chest;
            Waist = waist;
            Arm = arm;
            Thigh = thigh;
            Hips = hips;
            Weight = weight;
            Date = date;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Shoulders { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Arm { get; set; }
        public double Thigh { get; set; }
        public double Hips { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
    }
}
