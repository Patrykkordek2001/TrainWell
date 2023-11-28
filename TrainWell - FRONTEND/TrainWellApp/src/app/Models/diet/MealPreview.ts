import { MealEnum } from "./MealEnum";
import { ProductInMealPreview } from "./ProductInMealPreview";

export interface MealPreview{
    id: number;
    date: Date;
    mealName:MealEnum; // zamienic na enum;
    userId: number;
    productsInMeal: ProductInMealPreview;

    totalCalories: number;
    totalFat: number;
    totalSaturatedFat:number;
    totalCarbohydrates: number;
    totalSugars:number;
    totalSalt:number;
    totalProteins: number;
    totalFiber:number;
}