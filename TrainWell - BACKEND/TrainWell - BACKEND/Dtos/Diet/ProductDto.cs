using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Dtos.Diet
{
    public class ProductDto
    {
        public string Name { get; set; }

        //Kalorie oraz makroskładniki sa podawane na 100g
        public double Calories { get; set; }
        public double? Fat { get; set; }
        public double? StaruratedFat { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Sugars { get; set; }
        public double? Fiber { get; set; }
        public double? Proteins { get; set; }
        public double? Salt { get; set; }
        //public virtual ProductInMeal? ProductInMeal { get; set; }

    }
}
