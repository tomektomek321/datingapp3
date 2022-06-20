import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IdName } from 'src/app/shared/models/IdName';
import { Member } from 'src/app/shared/models/Member';
import { SearchUserDto } from 'src/app/shared/models/searchUsers/Dtos/SearchUserDto';
import { SearchUserParams } from 'src/app/shared/models/searchUsers/SearchUserParams';
import { environment } from 'src/environments/environment';
import { SearchBarService } from '../../search-bar/services/search-bar.service';
import { MemberListService } from './member-list.service';

@Injectable({
    providedIn: 'root'
})
export class MemberListRequestService {


    constructor(
        private searchBarService: SearchBarService,
        private mMemberListService: MemberListService,
        private http: HttpClient,
    ) { }

    createFilterParams(): SearchUserDto {
        const params: SearchUserParams = this.searchBarService.getSearchUserParams();

        const citiesString = this.createCitiesIdStringForRequest(params.cities);


        return {
            gender: params.gender,
            maxAge: params.maxAge,
            minAge: params.minAge,
            orderBy: params.orderBy,
            cities: citiesString,
        }
    }


    loadMembers(): void {
        const filterParams = this.createFilterParams();

        this.http.post<SearchUserDto>(environment.apiUrl + 'Member/FilterMembers', filterParams)
        .subscribe((response: any) => {
            const members: Member[] = response.data;
            console.log(members);
            this.mMemberListService.setSearchedMembers(members);
        })
    }

    createCitiesIdStringForRequest(cities: IdName[]) {
        let citiesString = ""

        cities.forEach(element => {
            citiesString += (element.id + "-")
        });

        citiesString = citiesString.slice(0, citiesString.length - 1);

        return citiesString;

    }




}
