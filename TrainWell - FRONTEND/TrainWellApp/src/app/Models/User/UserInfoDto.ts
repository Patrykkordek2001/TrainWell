import { ActivityEnum } from "./ActivityEnum";
import { GenderEnum } from "./GenderEnum";
import { GoalEnum } from "./GoalEnum";

export interface UserInfoDto{
    weight: number;
    growth: number;
    age: number;
    activity: ActivityEnum;
    gender: GenderEnum;
    goal: GoalEnum;
    //caloriesPerDay: number;
    //fatPerDay: number;
    //carbohydratesPerDay: number;
    //proteinsPerDay: number;
    userId:number;
}