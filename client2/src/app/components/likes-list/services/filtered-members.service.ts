import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Member } from 'src/app/shared/models/Member';

@Injectable({
  providedIn: 'root'
})
export class FilteredMembersService {

  filteredMembers: Member[] = [];

  filteredMembers$ = new BehaviorSubject<Member[]>(this.filteredMembers);

  constructor() { }

  setFilteredMembers(members_: Member[]) {
    this.filteredMembers = members_;
    this.filteredMembers$.next(this.filteredMembers);
  }

  getFilteredMembers = (): Member[] => this.filteredMembers;

  getFilteredMembers$ = () => this.filteredMembers$.asObservable();




}
