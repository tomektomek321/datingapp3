import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class HttpPaginationsService {

    constructor() { }

    private getPaginatedResult<T>(url, params) {
        /*const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
        return this.http.get<T>(url, { observe: 'response', params }).pipe(
            map(response => {
                paginatedResult.result = response.body;
                if (response.headers.get('Pagination') !== null) {
                    paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
                }
                return paginatedResult;
            })
        );*/
    }


    private getPaginationHeaders(pageNumber: number, pageSize: number) {
        /*let params = new HttpParams();

        params = params.append('pageNumber', pageNumber.toString());
        params = params.append('pageSize', pageSize.toString());

        return params;*/
    }





        /*var response = this.memberCache.get(Object.values(userParams).join('-'));
        if (response) {
            return of(response);
        }*/

        //let params = this.getPaginationHeaders(userParams.pageNumber, userParams.pageSize);
        /*let params = new HttpParams();
        params = params.append('minAge', userParams.minAge.toString());
        params = params.append('maxAge', userParams.maxAge.toString());
        params = params.append('gender', "0");
        params = params.append('orderBy', userParams.orderBy);
        if(userParams.cities.length > 0) {
            const citiesString = createCitiesIdStringForRequest(userParams.cities)
            params = params.append('cities', citiesString);
        }*/

        /*return this.getPaginatedResult<Member[]>(this.baseUrl + 'Member/FilterMembers', params)
            .pipe(map(response => {
                //this.memberCache.set(Object.values(userParams).join('-'), response);
                return response;
            }))*/

}
