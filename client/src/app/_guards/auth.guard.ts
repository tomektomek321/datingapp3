import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { map } from 'rxjs/operators';
import { UserService } from '../_services/user.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(
        private userService: UserService,
        private toastr: ToastrService) { }

    canActivate(): Observable<boolean> {
        return this.userService.getUserObs().pipe(
            map(user => {
              if (user) return true;
              this.toastr.error('You shall not pass!')
            })
          )
    }

}
