import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IdName } from 'src/app/shared/models/IdName';
import { SearchUserOrderByEnum } from 'src/app/shared/models/searchUsers/SearchUserOrderByEnum';
import { SearchUserParams } from 'src/app/shared/models/searchUsers/SearchUserParams';

@Injectable({
    providedIn: 'root'
})
export class SearchBarService {

    searchUserParams: SearchUserParams = {
        gender: 1,
        minAge: 18,
        maxAge: 50,
        cities: [],
        orderBy: SearchUserOrderByEnum.lastACtive,
    };

    searchUserParams$ = new BehaviorSubject<SearchUserParams>(this.searchUserParams);

    constructor() { }

    getSearchUserParams = (): SearchUserParams => this.searchUserParams;

    getSearchUserParams$ = () => this.searchUserParams$.asObservable();

    addCity(city_: IdName): void {
        const added = this.searchUserParams.cities.filter(item => item.id == city_.id);
        if(added.length > 0) {
            console.log("Already added");
            return;
        }

        this.searchUserParams.cities.push(city_);
        this.searchUserParams$.next(this.searchUserParams);
    }

    removeCity(city_: IdName): void{
        const added = this.searchUserParams.cities.filter(item => item.id != city_.id);
        this.searchUserParams.cities = added;
        this.searchUserParams$.next(this.searchUserParams);

    }

    resetParams(): void {
        this.searchUserParams = {
            gender: 1,
            minAge: 18,
            maxAge: 50,
            cities: [],
            orderBy: SearchUserOrderByEnum.lastACtive,
        };

        this.searchUserParams$.next(this.searchUserParams);
    }
}
