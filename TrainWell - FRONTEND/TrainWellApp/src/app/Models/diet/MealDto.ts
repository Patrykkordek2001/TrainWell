import { MealEnum } from "./MealEnum";
import { ProductInMealDto } from "./ProductInMealDto";


export interface MealDto{
    id: number;
    date: Date;
    mealName:MealEnum; // zamienic na enum;
    userId: number;
    productsInMeal: ProductInMealDto;

    // totalCalories: number;
    // totalFat: number;
    // totalSaturatedFat:number;
    // totalCarbohydrates: number;
    // totalSugars:number;
    // totalSalt:number;
    // totalProteins: number;
    // totalFiber:number;
}