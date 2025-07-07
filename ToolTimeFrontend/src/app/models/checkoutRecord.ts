import { Tool } from "./tool";

export interface CheckoutRecord {
    id: number;
    toolId: number;
    tool?: Tool; // Optional, for display only
    userId: string;
    checkoutDateTime: string;
    expectedReturnDateTime: string;
    actualReturn?: string | null; // Optional, can be null
}