import { MealPreview } from "./MealPreview";
import { ProductPreview } from "./ProductPreview";

export interface ProductInMealPreview {
    id: number;
    grams: number;
    productId: number; // zamienic na enum;
    product: ProductPreview;
    mealId: number;
    meal: MealPreview;

    gramsCalories: number;
    gramsFat: number;
    gramsSaturatedFat: number;
    gramsCarbohydrates: number;
    gramsSugars: number;
    gramsSalt: number;
    gramsProteins: number;
    gramsFiber: number;
}
