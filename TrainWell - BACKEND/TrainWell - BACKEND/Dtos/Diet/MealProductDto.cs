﻿namespace TrainWell___BACKEND.Dtos.Diet
{
    public class MealProductDto
    {
        public MealProductDto(double grams)
        {
            Grams = grams;
        }

        public double Grams { get; set; }
        public int ProductId { get; set; }

        //public virtual Product Product { get; set; }
        public int MealId { get; set; }

        //public virtual Meal Meal { get; set; }
    }
}