export class PaginationResponse<T> {
    data: T[];
    currentPage: number;
    totalPages: number;
    totalCount: number;
    pageSize: number;

    constructor(data: T[], count: number, page: number, pageSize: number) {
        this.data = data;
        this.currentPage = page;
        this.pageSize = pageSize;
        this.totalPages = Math.ceil(count / pageSize);
        this.totalCount = count;
    }

    get hasPreviousPage(): boolean {
        return this.currentPage > 1;
    }

    get hasNextPage(): boolean {
        return this.currentPage < this.totalPages;
    }
}
