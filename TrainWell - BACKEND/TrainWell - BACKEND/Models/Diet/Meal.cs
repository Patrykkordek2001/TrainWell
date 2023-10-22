using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class Meal
    {
        public Meal(DateTime date, MealNameEnum mealName)
        {
            Date = date;
            MealName = mealName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public MealNameEnum MealName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
