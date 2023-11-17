namespace TrainWell___BACKEND.Models.User
{
    public class UserInfo
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public int Growth { get; set; }
        public ActivityEnum Activity { get; set; }
        public GenderEnum Gender { get; set; }

        public int CaloriesPerDay { get; set; }
        public int FatPerDay { get; set; }
        public int CarbohydratesPerDay { get; set; }
        public int ProteinsPerDay { get; set; }


    }
}
