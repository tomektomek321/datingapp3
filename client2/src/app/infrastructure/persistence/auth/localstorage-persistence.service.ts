import { Injectable } from '@angular/core';
import { User } from 'src/app/shared/models/identity/User';

@Injectable({
    providedIn: 'root'
})
export class LocalstoragePersistenceService {

    constructor() { }

    getUser(): null | User {
        const user: null | string = localStorage.getItem('user');

        if(user != null) {
            const parsedUser: User = JSON.parse(user);
            return parsedUser;
        } else {
            return null;
        }
    }

    storeUser(user_: User): void {
        localStorage.setItem('user', JSON.stringify(user_));
    }

}
