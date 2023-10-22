using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class Product
    {
        public Product(string name, string? description, double calories, double? fat, double? staruratedFat, 
            double? carbohydrates, double? sugars, double? fiber, double? proteins, double? salt, int? dinnerId,
            int? lunchId, int? breakfastId, int? snackId, int? secondBreakfastId)
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
            DinnerId = dinnerId;
            LunchId = lunchId;
            BreakfastId = breakfastId;
            SnackId = snackId;
            SecondBreakfastId = secondBreakfastId;
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

        public virtual Dinner? Dinner { get; set; }
        public int? DinnerId { get; set; }
        public virtual Lunch? Lunch { get; set; }
        public int? LunchId { get; set; }
        public virtual Breakfast? Breakfast { get; set; }
        public int? BreakfastId { get; set; }
        public virtual Snack? Snack { get; set; }
        public int? SnackId { get; set; }
        public virtual SecondBreakfast? SecondBreakfast { get; set; }
        public int? SecondBreakfastId { get;set; }
    }
}
