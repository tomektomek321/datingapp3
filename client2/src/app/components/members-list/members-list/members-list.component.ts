import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { MemberListService } from '../services/member-list.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.scss']
})
export class MembersListComponent implements OnInit {

  membersList: Member[] = [];

  constructor(
    private memberListService: MemberListService,
  ) { }

  ngOnInit(): void {
    this.memberListService.searchedMembers$.subscribe(members_ => {
      this.membersList = members_;
    });
  }

}
