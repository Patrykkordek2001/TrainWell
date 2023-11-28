import { ProductInMealPreview } from "./ProductInMealPreview";

export interface ProductPreview {
    id: number;
    name: string;
    calories: number;
    fat: number;
    saturatedFat: number;
    carbohydrates: number;
    sugars: number;
    salt: number;
    proteins: number;
    fiber: number;
    productInMeal: ProductInMealPreview;
}