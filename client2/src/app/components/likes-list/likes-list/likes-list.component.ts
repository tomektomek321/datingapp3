import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { LikedByMembersService } from '../services/liked-by-members.service';
import { LikedMembersService } from '../services/liked-members.service';

@Component({
    selector: 'app-likes-list',
    templateUrl: './likes-list.component.html',
    styleUrls: ['./likes-list.component.scss']
})
export class LikesListComponent implements OnInit {

    predicate = 'liked';

    members: Member[] = [];

    constructor(
        private likedMembersService: LikedMembersService,
        private likedByMembersService: LikedByMembersService,
    ) { }

    ngOnInit(): void {
        this.loadLikes();

        this.likedMembersService.getLikedMembers$().subscribe((response: any) => {
            this.members = response;
        });

        this.likedByMembersService.getLikedByMembers$().subscribe((response: any) => {
            this.members = response;
        });
    }

    loadLikes(): void {
        this.predicate = 'liked';
        this.likedMembersService.fetchLikedMembers();
    }

    loadLikedBy() {
        this.predicate = 'likedBy';
        this.likedByMembersService.fetchLikedByMembers();
    }

}
