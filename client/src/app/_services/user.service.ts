import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    private user: User = null;

    currentUser = new BehaviorSubject<User>(this.user)

    constructor() { }

    getUserObs = () => this.currentUser.asObservable()
    getUser = (): User => this.user

    setUser = (user_: User) => {
        this.user = user_;
        localStorage.setItem('user', JSON.stringify(this.user));
        this.currentUser.next(this.user);
    }

}
