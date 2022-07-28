import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/infrastructure/auth/services/login/login.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    loginModel: {Username?: string, Password?: string} = {};

    constructor(
        private loginService: LoginService,
    ) { }

    ngOnInit(): void {

    }

    login() {
        this.loginService.login(this.loginModel).subscribe(response => {
        }, error => {
            console.log(error);
        })
    }

}
