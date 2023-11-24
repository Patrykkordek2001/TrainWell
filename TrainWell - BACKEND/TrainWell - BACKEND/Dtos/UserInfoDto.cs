using TrainWell___BACKEND.Models.User;

namespace TrainWell___BACKEND.Dtos
{
    public class UserInfoDto
    {
        public double Weight { get; set; }
        public int Growth { get; set; }
        public int Age { get; set; }
        public ActivityEnum Activity { get; set; }
        public GenderEnum Gender { get; set; }
        public GoalEnum Goal { get; set; }
        //public int CaloriesPerDay { get; set; }
        //public int FatPerDay { get; set; }
        //public int CarbohydratesPerDay { get; set; }
        //public int ProteinsPerDay { get; set; }

        public int UserId { get; set; }
    }
}
