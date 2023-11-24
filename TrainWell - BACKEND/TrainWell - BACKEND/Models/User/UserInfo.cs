using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TrainWell___BACKEND.Models.User
{
    public class UserInfo
    {
        public UserInfo(double weight, int growth, ActivityEnum activity, GenderEnum gender, GoalEnum goal)
        {
            Weight = weight;
            Growth = growth;
            Activity = activity;
            Gender = gender;
            Goal = goal;

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
         public GoalEnum Goal { get; set; }
        public int CaloriesPerDay { get; set; }
        public int FatPerDay { get; set; }
        public int CarbohydratesPerDay { get; set; }
        public int ProteinsPerDay { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

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

            switch (Goal)
            {
                case GoalEnum.Maintenance:
                    FatPerDay = (int)(caloriesPerDay * 0.25) / 9;
                    ProteinsPerDay = (int)(1.9 * Weight);
                    CarbohydratesPerDay = ((int)caloriesPerDay - (FatPerDay + ProteinsPerDay)) / 4;
                    break;
                case GoalEnum.Reduction:
                    caloriesPerDay *= 0.8;
                    FatPerDay = (int)(caloriesPerDay * 0.20) / 9;
                    ProteinsPerDay = (int)(2.0 * Weight);
                    CarbohydratesPerDay = ((int)caloriesPerDay - (FatPerDay + ProteinsPerDay)) / 4;
                    break;
                case GoalEnum.Gaining:
                    caloriesPerDay *= 1.2;
                    FatPerDay = (int)(caloriesPerDay * 0.25) / 9;
                    ProteinsPerDay = (int)(2.0 * Weight);
                    CarbohydratesPerDay = ((int)caloriesPerDay - (FatPerDay + ProteinsPerDay)) / 4;
                    break;

                default:
                    break;
            }

            

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
