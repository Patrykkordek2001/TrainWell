using System.ComponentModel.DataAnnotations.Schema;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Dtos.Diet
{
    public class MealDto
    {
        public MealDto(DateTime date, MealNameEnum mealName, ICollection<ProductInMeal>? productsInMeal)
        {
            Date = date;
            MealName = mealName;
            ProductsInMeal = productsInMeal;
        }

        public DateTime Date { get; set; }
        public MealNameEnum MealName { get; set; }
        public ICollection<ProductInMeal>? ProductsInMeal { get; set; }
        //[NotMapped]
        //public double TotalCalories
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsCalories) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalFat
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsFat) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalSaturatedFat
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsSaturatedFat) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalCarbohydrates
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsCarbohydrates) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalSugars
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsSugars) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalFiber
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsFiber) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalProteins
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsProteins) ?? 0;
        //    }
        //}
        //       //[NotMapped]
        //public double TotalSalt
        //{
        //    get
        //    {
        //        return ProductsInMeal?.Sum(p => p.GramsSalt) ?? 0;
        //    }
        //}
    }
}
