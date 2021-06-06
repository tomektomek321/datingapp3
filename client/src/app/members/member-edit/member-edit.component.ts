import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
    selector: 'app-member-edit',
    templateUrl: './member-edit.component.html',
    styleUrls: ['./member-edit.component.scss']
})
export class MemberEditComponent implements OnInit {
    member: Member;
    user: User;

    constructor(private accountService: AccountService, private memberService: MembersService) {

    }

    ngOnInit(): void {
        this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
            this.user = user
            this.loadMember()
        });
    }

    loadMember() {
        this.memberService.getMember(this.user.userName).subscribe(member => {
            this.member = member;
        })
    }

}
