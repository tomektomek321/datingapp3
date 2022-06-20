import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/app/shared/models/identity/User';
import { LocalstoragePersistenceService } from '../persistence/auth/localstorage-persistence.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

    user: User = {};

    user$ = new BehaviorSubject<User>(this.user);

    constructor(
        private _localstoragePersistenceService: LocalstoragePersistenceService,
    ) {
        const user = this._localstoragePersistenceService.getUser();

        if(user) {
            this.setUser(user);
        }
    }

    getUser = (): User => this.user;

    setUser = (user_: User) => {
        this.user = user_;
        this.user$.next(this.user);
    }

    getUser$ = () => this.user$.asObservable();
}
