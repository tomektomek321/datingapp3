import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserParams } from '../_models/userParams';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { UserService } from './user.service';
import { HttpResponse } from '../_models/HttpResponse';
import { createCitiesIdStringForRequest } from './utl';
import { ToastrService } from 'ngx-toastr';

export interface FilterParams {
    gender: string;
    minAge: number;
    maxAge: number;
    pageNumber: number;
    pageSize: number;
    orderBy: string;
    cities: string;
}

@Injectable({
    providedIn: 'root'
})
export class MembersService {

    baseUrl = environment.apiUrl;

    members: Member[] = [];

    user: User;

    userParams: UserParams;

    membersObs = new BehaviorSubject<Member[]>(this.members);

    constructor(
        private http: HttpClient,
        private userService: UserService,
        private toastr: ToastrService
    ) {

        this.userService.getUserObs().subscribe(user => {
            this.user = user;
            this.userParams = new UserParams(user);
        });
    }

    getMembersObs = () => this.membersObs;

    setMembers = (members_: Member[]): void => {
        this.members = members_;
        this.membersObs.next(this.members);
    }

    getUserParams = (): UserParams => this.userParams;

    setUserParams(params: UserParams): void {
        this.userParams = params;
    }

    resetUserParams() {
        this.userParams = new UserParams(this.user);
        return this.userParams;
    }

    createFilterParams(): FilterParams {
        return {
            gender: this.userParams.gender,
            maxAge: this.userParams.maxAge,
            minAge: this.userParams.minAge,
            orderBy: this.userParams.orderBy,
            pageSize: this.userParams.pageSize,
            pageNumber: this.userParams.pageNumber,
            cities: createCitiesIdStringForRequest(this.userParams.cities)
        }
    }

    getMembers(): void {
        const filterParams = this.createFilterParams();

        this.http.post(this.baseUrl + 'Member/FilterMembers', filterParams)
        .subscribe((response: HttpResponse<Member[]>) => {
            this.setMembers(response.data);
        })
    }

    GetUserDetails(): void {
        const UserId =  this.userService.getUser().id;

        this.http.post(this.baseUrl + 'Member/GetUserProfile', {UserId}).subscribe((response: HttpResponse<User>) => {console.log(response.data);
            this.userService.setUserProfileDetails(response.data);
        });
    }

    setMainPhoto = (photoId: number) => this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId, {});

    deletePhoto = (photoId: number) => this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId);


    toggleLike(memberId: number): void {
        const userId = this.userService.getUser().id;

        this.http.post(this.baseUrl + 'Like/LikeUser', {
            sourceUserId: userId,
            targetUserId: memberId
        }).subscribe((response: HttpResponse<number>) => {

            if(response.success) {
                this.userService.toggleLike(memberId);
                this.toastr.success("Userlike toggled");

            } else {
                this.toastr.error("Something bad happened.");
            }
        })
    }

    getLikedMembers(): void {
        const userId = this.userService.getUser().id;

        this.http.post(this.baseUrl + 'Member/GetLikedMembers', { userId })
        .subscribe((response: HttpResponse<Member[]>) => {
            this.setMembers(response.data);
        });
    }

    getLikedByMembers(): void {
        const userId = this.userService.getUser().id;

        this.http.post(this.baseUrl + 'Member/GetLikedByMembers', { userId })
        .subscribe((response: HttpResponse<Member[]>) => {
            this.setMembers(response.data);
        });
    }
}
