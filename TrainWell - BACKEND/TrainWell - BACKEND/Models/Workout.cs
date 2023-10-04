namespace TrainWell___BACKEND.Models
{

        public class Workout
        {
            public Workout(Guid id, string title, DateTime date)
            {
                Id = id;
                Title = title;
                Date = date;
            }

            public Guid Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public ICollection<Exercise> Exercises { get; set; }
        }
}
