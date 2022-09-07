import { Component, Input, OnInit } from '@angular/core';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { Member } from 'src/app/shared/models/Member';
import { LikedMembersService } from '../../likes-list/services/liked-members.service';

@Component({
    selector: 'app-member-card',
    templateUrl: './member-card.component.html',
    styleUrls: ['./member-card.component.scss']
})
export class MemberCardComponent implements OnInit {

    @Input() member!: Member;

    constructor(
        private userManagerService: UserManagerService,
        private likedMembersService: LikedMembersService,
    ) { }

    ngOnInit(): void { }

    toggleLike() {
        this.likedMembersService.toggleLike(this.member.id);
    }

    isLikedByUser = (): string => this.userManagerService.isLikedByUser(this.member.id) ? "btn-success" : "btn-primary";
}
