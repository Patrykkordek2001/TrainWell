using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Dtos.Diet
{
    public class ProductInMealDto
    {
        public ProductInMealDto(double grams)
        {
            Grams = grams;
        }

        public double Grams { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }

    }
}
