import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { SearchUserParams } from 'src/app/shared/models/searchUsers/SearchUserParams';
import { MemberListRequestService } from '../../members-list/services/member-list-request.service';
import { SearchBarService } from '../services/search-bar.service';

@Component({
    selector: 'app-search-bar',
    templateUrl: './search-bar.component.html',
    styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

    searchUserParams?: SearchUserParams;

    members: Member[] = [];

    genderList = [{ value: '1', display: 'Males' }, { value: '0', display: 'Females' }];

    constructor(
        private searchBarService: SearchBarService,
        private memberListRequestService: MemberListRequestService,
    ) {

    }

    ngOnInit(): void {
        this.searchBarService.getSearchUserParams$().subscribe( (params_: SearchUserParams) => {
            this.searchUserParams = params_;
        });
    }

    removeHobby(item: any) {

    }

    loadMembers(): void {
        this.memberListRequestService.loadMembers();
    }

    resetFilters(): void {
        this.searchBarService.resetParams();
    }

    addCity(city_: any): void {
        if(this.searchUserParams) {
            this.searchBarService.addCity(city_);
        }
    }

}
