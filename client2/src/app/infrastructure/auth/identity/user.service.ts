import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/app/shared/models/auth/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

    user: User = {};

    user$ = new BehaviorSubject<User>(this.user);

    constructor() { }

    getUser = (): User => this.user;

    setUser = (user_: User) => {
        this.user = user_;
        this.user$.next(this.user);
    }

    getUser$ = () => this.user$.asObservable();
}
