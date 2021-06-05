import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
    model: any = {}
    currentUser$: Observable<User>

    constructor(private accountService: AccountService, private router: Router) { }

    ngOnInit(): void {
        this.currentUser$ = this.accountService.currentUser$
    }

    login() {
        this.accountService.login(this.model).subscribe(response => {
            console.log(response)
            this.router.navigateByUrl('/members')
        }, error => {
            console.log(error)
        })
    }

    logout() {
        this.accountService.logout()
        this.router.navigateByUrl('/')
    }

}
