
export interface HttpResponse<T> {
    status: number;
    success: boolean;
    message: string;
    validationErrors: string[];
    data: T;
}
