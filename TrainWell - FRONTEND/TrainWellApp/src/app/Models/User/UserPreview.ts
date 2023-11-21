import { UserInfo } from "./UserInfo";

export interface UserPreview{
    id: number;
    username: string;
    email: string;
    password: string;
    phoneNumber: string;
    userInfo: UserInfo;
}