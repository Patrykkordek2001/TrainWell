using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public ICollection<ProductInMeal>? ProductsInMeal { get; set; }


        [NotMapped]
        public double TotalCalories
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsCalories) ?? 0;
            }
        }

        [NotMapped]
        public double TotalFat
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsFat) ?? 0;
            }
        }

        [NotMapped]
        public double TotalSaturatedFat
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsSaturatedFat) ?? 0;
            }
        }

        [NotMapped]
        public double TotalCarbohydrates
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsCarbohydrates) ?? 0;
            }
        }

        [NotMapped]
        public double TotalSugars
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsSugars) ?? 0;
            }
        }

        [NotMapped]
        public double TotalFiber
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsFiber) ?? 0;
            }
        }

        [NotMapped]
        public double TotalProteins
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsProteins) ?? 0;
            }
        }

        [NotMapped]
        public double TotalSalt
        {
            get
            {
                return ProductsInMeal?.Sum(p => p.GramsSalt) ?? 0;
            }
        }
    }
}
