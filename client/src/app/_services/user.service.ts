import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    private user: User = {
        userName: null,
        gender: null,
        photoUrl: null,
        knownAs: null,
        token: null,
    };

    currentUser = new BehaviorSubject<User>(this.user)

    constructor() { }

    getUser = () => this.currentUser.asObservable()

    setUser = (user_: User) => {
        this.user = user_;
        this.currentUser.next(this.user);
    }

}
