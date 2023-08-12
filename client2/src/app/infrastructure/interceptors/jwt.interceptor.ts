import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { UserService } from '../identity/user.service';
import { AppUser } from 'src/app/shared/models/identity/AppUser';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private userService: UserService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler)
  : Observable<HttpEvent<unknown>> {
    this.userService.getUser$().pipe(take(1)).subscribe({
      next: (user: AppUser) => {
        if (user) {
          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${user.token}`,
            },
          });
        }
      },
    });

    return next.handle(request);
  }
}
