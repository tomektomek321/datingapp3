import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators'
import { User } from 'src/app/shared/models/identity/User';
import { HttpResponse } from 'src/app/shared/models/http/HttpResponse';
import { environment } from 'src/environments/environment';
import { UserService } from '../../../identity/user.service';

@Injectable({
    providedIn: 'root'
})
export class RegisterService {

    constructor(
        private router: Router,
        private http: HttpClient,
        private userService: UserService,
    ) { }

    register(model: any) {debugger

        console.log(model.dateOfBirth.toString());
        console.log(model.dateOfBirth.getDate());
        console.log(model.dateOfBirth.toUTCString());



        //new Date().toLocaleDateString()

        //model.dateOfBirth = model.dateOfBirth.toUTCString();
        //model.dateOfBirth = model.dateOfBirth.replace(",", "");
        const newDate = new Date()
        return this.http.post(environment.apiUrl + 'account/register', model).pipe(

            map((response: any) => { debugger
                const user: HttpResponse<User> = response;
                if(user.success) {
                    this.userService.setUser(response.data);
                    this.router.navigateByUrl('/searchMembers');
                }

            }, (error: any) => {debugger
                console.log(error);
                return "error";
            })
        )
    }
}
