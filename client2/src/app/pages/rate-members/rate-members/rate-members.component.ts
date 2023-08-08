import { Component, OnInit } from '@angular/core';
import { FilteredMembersService } from 'src/app/components/likes-list/services/filtered-members.service';
import { Member } from 'src/app/shared/models/Member';

@Component({
  selector: 'app-rate-members',
  templateUrl: './rate-members.component.html',
  styleUrls: [ './rate-members.component.scss' ],
})
export class RateMembersComponent implements OnInit {
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
