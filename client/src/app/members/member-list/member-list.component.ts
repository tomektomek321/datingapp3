import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { Pagination } from 'src/app/_models/pagination';
import { UserParams } from 'src/app/_models/userParams';
import { User } from 'src/app/_models/user';

@Component({
    selector: 'app-member-list',
    templateUrl: './member-list.component.html',
    styleUrls: ['./member-list.component.scss']
})
export class MemberListComponent implements OnInit {
    members: Member[];
    pagination: Pagination;
    userParams: UserParams;
    user: User;
    genderList = [{ value: '1', display: 'Males' }, { value: '0', display: 'Females' }];

    constructor(private memberService: MembersService) {
        this.userParams = this.memberService.getUserParams();
    }

    ngOnInit(): void {
        this.memberService.getMembersObs().subscribe((response: Member[]) => {
            this.members = JSON.parse(JSON.stringify(response));
        })

        this.memberService.getMembers();
    }

    loadMembers(): void {
        this.memberService.setUserParams(this.userParams);
        this.memberService.getMembers();
    }

    resetFilters(): void {
        this.userParams = this.memberService.resetUserParams();
        this.loadMembers();
    }

    pageChanged(event: any): void {
        this.userParams.pageNumber = event.page;
        this.memberService.setUserParams(this.userParams);
        this.loadMembers();
    }

    getValue($event) {
        this.userParams.cities.push($event);
    }

    addHobby() {

    }

}
