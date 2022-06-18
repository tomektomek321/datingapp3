import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../../_models/user';
import { AccountService } from '../../_services/account.service';
import { UserService } from '../../_services/user.service';

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
    model: any = {};
    currentUser$: Observable<User>;

    constructor(
        private accountService: AccountService,
        private userService: UserService,
        private toastr: ToastrService) {}

    ngOnInit(): void {
        this.currentUser$ = this.userService.getUserObs();
    }

    login() {
        this.accountService.login(this.model).subscribe(response => {

        }, error => {
            this.toastr.error(error.error);
        })
    }

    logout() {
        this.accountService.logout();
    }

}
