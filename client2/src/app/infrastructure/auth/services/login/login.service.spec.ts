import { Location } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { LoginService } from './login.service';


describe('LoginService', () => {
    let service: LoginService;
    let router: Router;
    let location: Location;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                HttpClientModule,
            ]
        });
        service = TestBed.inject(LoginService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });


    it('User ana12 -> ana12 return login 10', (done) => {

        service.login({username: "ana12", password: "ana12"}).subscribe((user_: any) => {
            expect(user_.id).toBe(10);
            done();
        })

    });


});
