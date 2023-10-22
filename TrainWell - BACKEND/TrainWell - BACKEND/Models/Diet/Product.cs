using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class Product
    {
        public Product(string name, string? description, double calories, double? fat, double? staruratedFat, 
            double? carbohydrates, double? sugars, double? fiber, double? proteins, double? salt)
        {
            Name = name;
            Description = description;
            Calories = calories;
            Fat = fat;
            StaruratedFat = staruratedFat;
            Carbohydrates = carbohydrates;
            Sugars = sugars;
            Fiber = fiber;
            Proteins = proteins;
            Salt = salt;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public double Calories { get; set; }
        public double?  Fat { get; set; }
        public double? StaruratedFat { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Sugars { get; set; }
        public double? Fiber { get; set; }
        public double? Proteins { get; set; }
        public double? Salt { get; set; }

        public virtual Meal? Meal { get; set; }
        public int? MealId { get; set; }

    }
}
