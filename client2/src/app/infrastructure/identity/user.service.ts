import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppUser } from 'src/app/shared/models/identity/AppUser';
import { LocalstoragePersistenceService } from '../persistence/auth/localstorage-persistence.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user: AppUser = {
    id: 0,
  };

  user$ = new BehaviorSubject<AppUser>(this.user);

  constructor(
    private _localstoragePersistenceService: LocalstoragePersistenceService,
  ) {
    const user = this._localstoragePersistenceService.getUser();

    if (user) this.setUser(user);
  }

  getUser = (): AppUser => this.user;

  setUser = (user_: AppUser) => {
    if (user_.id == 0) {
      this._localstoragePersistenceService.removeUser();
    } else {
      this._localstoragePersistenceService.storeUser(user_);
    }
    this.user = user_;
    this.user$.next(this.user);
  };

  logout() {
    this._localstoragePersistenceService.removeUser();
    this.user = { id: 0 };
    this.user$.next(this.user);
  }

  getUser$ = () => this.user$.asObservable();
}
