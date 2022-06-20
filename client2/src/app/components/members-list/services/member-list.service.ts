import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Member } from 'src/app/shared/models/Member';

@Injectable({
    providedIn: 'root'
})
export class MemberListService {

    searchedMembers: Member[] = [];

    searchedMembers$ = new BehaviorSubject<Member[]>(this.searchedMembers);

    constructor() { }

    setSearchedMembers(members_: Member[]) {
        this.searchedMembers = members_;
        this.searchedMembers$.next(this.searchedMembers);
    }

    getSearchedMembers = (): Member[] => this.searchedMembers;

    getSearchedMembers$ = () => this.searchedMembers$.asObservable();

}
