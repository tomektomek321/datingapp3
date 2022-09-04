import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { Member } from 'src/app/shared/models/Member';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LikedMembersService {

    likedMembers: Member[] = [];

    likedMembers$ = new BehaviorSubject<Member[]>(this.likedMembers);

    constructor(
        private http: HttpClient,
        private userService: UserService,
    ) {

    }

    setLikedMembers(members_: Member[]) {
        this.likedMembers = members_;
        this.likedMembers$.next(this.likedMembers);
    }

    getLikedMembers = (): Member[] => this.likedMembers;

    getLikedMembers$ = () => this.likedMembers$.asObservable();

    fetchLikedMembers() {

        const userId = this.userService.getUser().id;

        this.http.post(environment.apiUrl + 'Member/GetLikedMembers', { userId })
        .subscribe((response: any) => {
            this.setLikedMembers(response.data);
        });

    }
}
