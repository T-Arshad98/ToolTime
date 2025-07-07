import { User } from "./user";

export interface UserRole {
    userId: string;
    user?: User;
    roleName: string;
}