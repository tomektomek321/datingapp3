import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { Member } from 'src/app/shared/models/Member';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LikedByMembersService {

    likedByMembers: Member[] = [];

    likedByMembers$ = new BehaviorSubject<Member[]>(this.likedByMembers);

    constructor(
        private http: HttpClient,
        private userService: UserService,
    ) {

    }

    setLikedByMembers(members_: Member[]) {
        this.likedByMembers = members_;
        this.likedByMembers$.next(this.likedByMembers);
    }

    getLikedByMembers = (): Member[] => this.likedByMembers;

    getLikedByMembers$ = () => this.likedByMembers$.asObservable();

    fetchLikedByMembers() {

        const userId = this.userService.getUser().id;

        this.http.post(environment.apiUrl + 'Member/GetLikedByMembers', { userId })
        .subscribe((response: any) => {
            this.setLikedByMembers(response.data);
        });

    }
}
