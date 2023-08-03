import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { FilteredMembersService } from '../../likes-list/services/filtered-members.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: [ './members-list.component.scss' ],
})
export class MembersListComponent implements OnInit {

  membersList: Member[] = [];

  constructor(
    private filteredMembersService: FilteredMembersService,
  ) { }

  ngOnInit(): void {
    this.filteredMembersService.getFilteredMembers$()
      .subscribe((members_: Member[]) => {
        console.log(members_);
        this.membersList = members_;
      });
  }
}
