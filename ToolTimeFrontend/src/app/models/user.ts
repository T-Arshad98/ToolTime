import { UserRole } from "./userRole";

export interface User {
    id: string;
    username: string;
    password?: string;
    roles: UserRole[];
}