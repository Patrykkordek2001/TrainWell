using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Calories { get; set; }
        public double  Fat { get; set; }
        public double StaruratedFat { get; set; }
        public double Carbohydrates { get; set; }
        public double Sugars { get; set; }
        public double Fiber { get; set; }
        public double Proteins { get; set; }
        public double Salt { get; set; }

        public virtual Dinner Dinner { get; set; }
        public virtual Lunch Lunch { get; set; }
        public virtual Breakfast Breakfast { get; set; }
        public virtual Snack Snack { get; set; }
        public virtual SecondBreakfast SecondBreakfast { get; set; }
    }
}
