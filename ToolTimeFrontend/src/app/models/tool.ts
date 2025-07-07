export interface Tool {
    id: number;
    name: string;
    type: string;
    serialNumber: string;
    description?: string;
    lastInspectionDate?: string;
}