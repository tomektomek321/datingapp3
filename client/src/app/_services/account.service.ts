import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';
import { HttpResponse } from '../_models/HttpResponse';

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    baseUrl = environment.apiUrl;
    user: User;
    private currentUserSource = new ReplaySubject<User>(1)
    currentUser$ = this.currentUserSource.asObservable()

    constructor(private http: HttpClient) { }

    login(model: any) {
        return this.http.post(this.baseUrl + 'account/login', model).pipe(
            map( (response: HttpResponse<User>) => {
                const user = response
                if(user) {
                    this.setCurrentUser(response.Data)
                }
            })
        )
    }

    register(model: any) {
        return this.http.post(this.baseUrl + 'account/register', model).pipe(
          map((user: User) => {
            if (user) {
                this.setCurrentUser(user)
            }
          }, error => {
            console.log(error)
        })
        )
    }

    setCurrentUser(user: User) {
        this.user = user;
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user)
    }

    logout() {
        localStorage.removeItem('user')
        this.currentUserSource.next(null)
    }

    getUser = () => this.user
}
