namespace TrainWell___BACKEND.Dtos
{
    public class MeasurementsDto
    {
        public MeasurementsDto(DateTime date, double shoulders, double chest, double waist, double arm, double thigh, double hips, double weight)
        {
            Date = date.ToLocalTime();
            Shoulders = shoulders;
            Chest = chest;
            Waist = waist;
            Arm = arm;
            Thigh = thigh;
            Hips = hips;
            Weight = weight;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Shoulders { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Arm { get; set; }
        public double Thigh { get; set; }
        public double Hips { get; set; }
        public double Weight { get; set; }
    }
}
