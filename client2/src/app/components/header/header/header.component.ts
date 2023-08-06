import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginService } from 'src/app/infrastructure/auth/services/login/login.service';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { User } from 'src/app/shared/models/identity/User';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: [ './header.component.scss' ],
})
export class HeaderComponent implements OnInit {
  user$: Observable<User>;

  menuShowed: boolean = false;

  constructor(
    private userService: UserService,
    private loginService: LoginService,
  ) {
    this.user$ = this.userService.getUser$();
  }

  ngOnInit(): void { }

  logout() {
    this.loginService.logout();
  }

  openMenu() {
    this.menuShowed = !this.menuShowed;
  }

  isMenuShowed() {
    if (this.menuShowed) {
      return 'show-menu';
    } else {
      return '';
    }
  }
}
