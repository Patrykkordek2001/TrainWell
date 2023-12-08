using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class MealProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Grams { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }


        [NotMapped]
        public double GramsCalories
        {
            get
            {
                return Product.Calories * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsFat
        {
            get
            {
                return (Product.Fat ?? 0) * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsSaturatedFat
        {
            get
            {
                return (Product.StaruratedFat ?? 0) * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsCarbohydrates
        {
            get
            {
                return (Product.Carbohydrates ?? 0) * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsSugars
        {
            get
            {
                return (Product.Sugars ?? 0) * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsFiber
        {
            get
            {
                return (Product.Fiber ?? 0) * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsProteins
        {
            get
            {
                return (Product.Proteins ?? 0) * Grams / 100;
            }
        }
        [NotMapped]
        public double GramsSalt
        {
            get
            {
                return (Product.Salt ?? 0) * Grams / 100;
            }
        }



    }
}
