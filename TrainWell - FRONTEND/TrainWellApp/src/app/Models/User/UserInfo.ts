import { ActivityEnum } from "./ActivityEnum";
import { GenderEnum } from "./GenderEnum";

export interface UserInfo{
    id : number;
    weight: number;
    growth: number;
    age: number;
    activity: ActivityEnum;
    gender: GenderEnum;
    caloriesPerDay: number;
    fatPerDay: number
    carbohydratesPerDay: number
    proteinsPerDay: number
}