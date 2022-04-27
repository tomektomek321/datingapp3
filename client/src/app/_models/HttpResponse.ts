
export interface HttpResponse<T> {
    status: number;
    success: boolean;
    massage: string;
    validationErrors: string[];
    data: T
}


export interface RegisterResponse<T> extends HttpResponse<T> {

}








