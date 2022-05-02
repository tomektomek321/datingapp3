import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { LikedUsers, User } from 'src/app/_models/user';
import { MembersService } from 'src/app/_services/members.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
    selector: 'app-lists',
    templateUrl: './lists.component.html',
    styleUrls: ['./lists.component.scss']
})
export class ListsComponent implements OnInit {

    members: Partial<Member[]>;
    user: User;
    predicate = 'liked';
    pageNumber = 1;
    pageSize = 5;
    pagination: Pagination;

    constructor(
        private memberService: MembersService,
        private userService: UserService,
        ) { }

    ngOnInit(): void {
        this.memberService.getMembersObs().subscribe(response => {
            console.log(response);
            this.members = JSON.parse(JSON.stringify(response));
        })

        this.userService.getUserObs().subscribe((response: User) => {
            console.log(response);
            if(this.predicate == "likedBy") return;
            this.removedDislikedMembers(response.likedUsers);
        })

        this.loadLikes();
    }

    removedDislikedMembers(likedUsers: LikedUsers[]) {

        const likedIds: number[] = likedUsers.map((item, idx) => item.targetId);

        console.log(likedIds);
        let foundIndex: number;
        this.members.forEach((member_, index_) => {
            if(!likedIds.includes(member_.id)) {
                foundIndex = index_;
            }
        });

        this.members.splice(foundIndex, 1);
    }

    loadLikes() {
        this.predicate = 'liked';
        this.memberService.getLikedMembers();
    }

    loadLikedBy() {
        this.predicate = 'likedBy';
        this.memberService.getLikedByMembers();
    }

    pageChanged(event: any) {
        this.pageNumber = event.page;
        this.loadLikes();
    }

}
