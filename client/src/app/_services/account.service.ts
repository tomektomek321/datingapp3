import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';
import { HttpResponse } from '../_models/HttpResponse';
import { UserService } from './user.service';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    baseUrl = environment.apiUrl;
    user: User;
    private currentUserSource = new ReplaySubject<User>(1);
    currentUser$ = this.currentUserSource.asObservable();

    constructor(
        private router: Router,
        private http: HttpClient,
        private userService: UserService
    ) {

        const savedUser = JSON.parse(localStorage.getItem('user'));
        if(savedUser) {
            this.userService.setUser(savedUser);
        }

    }

    login(model: any) {
        return this.http.post(this.baseUrl + 'account/login', model).pipe(
            map( (response: HttpResponse<User>) => {
                const user = response
                if(user.success) {
                    this.userService.setUser(response.data);
                    this.router.navigateByUrl('/members');
                }
                return 1;
            })
        )
    }

    register(model: any) {
        return this.http.post(this.baseUrl + 'account/register', model).pipe(
            map((response: HttpResponse<User>) => { console.log(response)
                const user = response;
                if(user.success) {
                    this.userService.setUser(response.data);
                    this.router.navigateByUrl('/members');
                }
            }, error => {
                console.log(error)
            })
        )
    }

    setCurrentUser(user: User) {
        //this.user = user;
        this.userService.setUser(user);
    }

    logout() {
        localStorage.removeItem('user');
        this.userService.setUser(null);
        this.router.navigateByUrl('/');
    }

    getUser = () => this.user;
}
