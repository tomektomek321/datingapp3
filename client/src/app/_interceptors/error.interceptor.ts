import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router, private toastr: ToastrService) { }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request).pipe(
            catchError(error => {
                if (error) {
                    switch (error.status) {
                        case 401:
                            this.toastr.error(error.statusText, error.status);
                            break;
                        case 404:
                            this.router.navigateByUrl('/not-found');
                            break;
                        default:
                            this.toastr.error('Something unexpected went wrong');
                            break;
                    }
                }
                return throwError(error);
            })
        )
    }
}
