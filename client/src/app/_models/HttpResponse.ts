
export interface HttpResponse<T> {
    Status: number;
    Success: boolean;
    Massage: string;
    ValidationErrors: string[];
    Data: T
}


export interface RegisterResponse<T> extends HttpResponse<T> {

}








