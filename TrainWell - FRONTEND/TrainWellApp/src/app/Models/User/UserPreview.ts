import { UserInfo } from "./UserInfo";

export interface UserPreview{
    id: number;
    username: string;
    email: string;
    userInfo: UserInfo;
}