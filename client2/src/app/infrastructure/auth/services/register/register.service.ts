import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { AppUser } from 'src/app/shared/models/identity/AppUser';
import { HttpResponse } from 'src/app/shared/models/http/HttpResponse';
import { environment } from 'src/environments/environment';
import { UserService } from '../../../identity/user.service';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  constructor(
    private router: Router,
    private http: HttpClient,
    private userService: UserService,
  ) { }

  register(model: any) {
    console.log(model.dateOfBirth.toString());
    console.log(model.dateOfBirth.getDate());
    console.log(model.dateOfBirth.toUTCString());

    //new Date().toLocaleDateString()
    //model.dateOfBirth = model.dateOfBirth.toUTCString();
    //model.dateOfBirth = model.dateOfBirth.replace(",", "");

    return this.http.post(environment.apiUrl + 'account/register', model).pipe(
      map((response: any) => {
        const user: HttpResponse<AppUser> = response;

        if(user.success) {
          this.userService.setUser(response.data);
          this.router.navigateByUrl('/searchMembers');
        }
      }, (error: any) => {
        console.log(error);

        return 'RegisterService.Register() error';
      }),
    );
  }
}
