import { Injectable } from '@angular/core';
import { AppUser } from 'src/app/shared/models/identity/AppUser';

@Injectable({
  providedIn: 'root',
})
export class LocalstoragePersistenceService {
  constructor() { }

  getUser(): null | AppUser {
    const user: null | string = localStorage.getItem('user');

    if(user != null) {
      const parsedUser: AppUser = JSON.parse(user);

      return parsedUser;
    } else {
      return null;
    }
  }

  storeUser(user_: AppUser): void {
    localStorage.setItem('user', JSON.stringify(user_));
  }

  removeUser() {
    localStorage.removeItem('user');
  }
}
