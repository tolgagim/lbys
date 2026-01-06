export class ResponseModel<T>{
    data: T | any;
    errorMessages: string[] = [];
    isSuccess: boolean = false;
    currentPage: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
}