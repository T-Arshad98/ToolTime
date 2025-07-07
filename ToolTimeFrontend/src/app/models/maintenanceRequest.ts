import { Tool } from "./tool";

export interface MaintenanceRequest {
    id: number;
    toolId: number;
    tool: Tool;
    userId: string;
    issueDesc: string;
    status: string
    createdAt: string;
    resolvedAt?: string;
}