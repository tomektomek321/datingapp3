import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    private user: User = null;

    currentUser = new BehaviorSubject<User>(this.user);

    constructor() { }

    getUserObs = () => this.currentUser.asObservable();

    getUser = (): User => this.user;

    setUser = (user_: User): void => {
        this.user = user_;
        localStorage.setItem('user', JSON.stringify(this.user));
        this.currentUser.next(this.user);
    }

    setUserProfileDetails = (user_: User): void => {

        this.user.hobbies = user_.hobbies;
        this.user.city = user_.city;
        this.user.country = user_.country;
        this.user.age = user_.age;
        this.user.lastActive = user_.lastActive;

        localStorage.setItem('user', JSON.stringify(this.user));
        this.currentUser.next(this.user);
    }

    toggleLike(memberId: number): void {
        if(this.isLikedByUser(memberId)) {
            const index = this.user.likedUsers.findIndex(user_ => user_.likedUserId == memberId);
            this.user.likedUsers.splice(index, 1);
            this.setUser(this.user);
        } else {
            this.user.likedUsers.push({
                sourceId: this.user.id,
                likedUserId: memberId
            });
            this.setUser(this.user);
        }
    }

    isLikedByUser = (memberId: number): boolean => this.user.likedUsers.some(user_ => user_.likedUserId == memberId);

    updateCity(cityObject): void {
        this.user.city = cityObject;
        localStorage.setItem('user', JSON.stringify(this.user));
        this.currentUser.next(this.user);
    }

    updateCountry(countryObject): void {
        this.user.country = countryObject;
        localStorage.setItem('user', JSON.stringify(this.user));
        this.currentUser.next(this.user);
    }

}
