import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
    selector: 'app-member-card',
    templateUrl: './member-card.component.html',
    styleUrls: ['./member-card.component.scss']
})
export class MemberCardComponent implements OnInit {

    @Input() member: Member;

    constructor(
        private memberService: MembersService,
        private userServuce: UserService,
    ) { }

    ngOnInit(): void { }

    addLike(): void {
        this.memberService.toggleLike(this.member.id);
    }

    isLikedByUser = (): string => this.userServuce.isLikedByUser(this.member.id) ? "btn-success" : "btn-primary";

}
