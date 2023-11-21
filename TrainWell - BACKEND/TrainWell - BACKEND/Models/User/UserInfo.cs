using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.User
{
    public class UserInfo
    {
        public UserInfo(double weight, int growth, ActivityEnum activity, GenderEnum gender, int caloriesPerDay, int fatPerDay, int carbohydratesPerDay, int proteinsPerDay)
        {
            Weight = weight;
            Growth = growth;
            Activity = activity;
            Gender = gender;

            CalculateDailyCalories();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Weight { get; set; }
        public int Growth { get; set; }
        public int Age { get; set; }
        public ActivityEnum Activity { get; set; }
        public GenderEnum Gender { get; set; }

        public int CaloriesPerDay { get; set; }
        public int FatPerDay { get; set; }
        public int CarbohydratesPerDay { get; set; }
        public int ProteinsPerDay { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public void CalculateDailyCalories()
        {
            double bmr;

            if (Gender == GenderEnum.Male)
            {
                bmr = 88.362 + (13.397 * Weight) + (4.799 * Growth) - (5.677 * Age);
            }
            else
            {
                bmr = 447.593 + (9.247 * Weight) + (3.098 * Growth) - (4.330 * Age);
            }

            double activityMultiplier = GetActivityMultiplier();
            double caloriesPerDay = bmr * activityMultiplier;

            CaloriesPerDay = (int)caloriesPerDay;
        }


        private double GetActivityMultiplier()
        {
            switch (Activity)
            {
                case ActivityEnum.Resting:
                    return 1.25;
                case ActivityEnum.Low:
                    return 1.4;
                case ActivityEnum.Average:
                    return 1.6;
                case ActivityEnum.ActiveLifestyle:
                    return 1.75;
                case ActivityEnum.VeryActiveLifestyle:
                    return 2.0;
                case ActivityEnum.ProfessionallyPracticingSports:
                    return 2.35;
                default:
                    return 0.0;
            }
        }
    }
}
