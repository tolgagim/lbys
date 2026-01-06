interface PaginationFilter {
    pageNumber: number;
    pageSize: number;
    orderBy?: string[];
}

class PaginationFilterExtensions {
    static hasOrderBy(filter: PaginationFilter): boolean {
        return filter.orderBy && filter.orderBy.length > 0;
    }
}
