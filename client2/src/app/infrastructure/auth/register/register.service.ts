import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject, catchError, Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { User } from 'src/app/shared/models/auth/User';
import { HttpResponse } from 'src/app/shared/models/http/HttpResponse';
import { environment } from 'src/environments/environment';
import { UserService } from '../identity/user.service';

@Injectable({
    providedIn: 'root'
})
export class RegisterService {

    constructor(
        private router: Router,
        private http: HttpClient,
        private userService: UserService,
    ) { }

    register(model: any) {
        return this.http.post(environment.apiUrl + 'account/register', model).pipe(

            map((response: any) => {
                const user: HttpResponse<User> = response;
                if(user.success) {
                    this.userService.setUser(response.data);
                    this.router.navigateByUrl('/searchMembers');
                }

            }, (error: any) => {
                this.router.navigateByUrl('/searchMembers');
                return "error";
            })
        )
    }
}
