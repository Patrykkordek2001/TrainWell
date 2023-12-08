using System.ComponentModel.DataAnnotations.Schema;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Dtos.Diet
{
    public class MealDto
    {
        public MealDto(DateTime date, MealNameEnum mealName, ICollection<MealProductDto>? productsInMeal)
        {
            Date = date.ToLocalTime();
            MealName = mealName;
            ProductsInMeal = productsInMeal;
            SetTimeOfMeal();
        }

        public DateTime Date { get; set; }
        public MealNameEnum MealName { get; set; }
        public ICollection<MealProductDto>? ProductsInMeal { get; set; }
        
        public void SetTimeOfMeal()
        {
            if (MealName == MealNameEnum.Breakfast) Date = Date.Date.AddHours(8);
            else if (MealName == MealNameEnum.SecondBreakfast) Date = Date.Date.AddHours(10);
            else if (MealName == MealNameEnum.Lunch) Date = Date.Date.AddHours(12);
            else if (MealName == MealNameEnum.Snack) Date = Date.Date.AddHours(15);
            else if (MealName == MealNameEnum.Dinner) Date = Date.Date.AddHours(18);
        }
    }
}
