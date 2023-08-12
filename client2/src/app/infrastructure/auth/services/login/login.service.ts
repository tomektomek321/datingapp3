import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { UserService } from '../../../identity/user.service';
import { map } from 'rxjs/operators';
import { AppUser } from 'src/app/shared/models/identity/AppUser';
import { HttpResponse } from 'src/app/shared/models/http/HttpResponse';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(
    private router: Router,
    private http: HttpClient,
    private userService: UserService,
  ) { }

  login(model: any) {
    return this.http.post(environment.apiUrl + 'account/login', model).pipe(

      map((response: any) => {
        const user: HttpResponse<AppUser> = response;

        if(user.success) {
          this.userService.setUser(response.data);
          this.router.navigateByUrl('/searchMembers');
        }

        return response.data;
      // eslint-disable-next-line @typescript-eslint/no-unused-vars
      }, (error: any) => {
        return 'LoginService.Login() error';
      }),
    );
  }

  logout() {
    this.userService.logout();
  }
}
