namespace TrainWell___BACKEND.Models
{

        public class Workout
        {
            public Workout(int id, string title, DateTime date)
            {
                Id = id;
                Title = title;
                Date = date;
            }

            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public ICollection<Exercise> Exercises { get; set; }
        }
}
