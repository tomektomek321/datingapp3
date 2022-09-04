import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'src/app/shared/models/identity/User';
import { environment } from 'src/environments/environment';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService {

    constructor(
        private userService: UserService,
        private http: HttpClient,
    ) {

    }

    GetUserDetails() {
        const User =  this.userService.getUser();

        const UserId = User.id;

        this.http.post(environment.apiUrl + 'Member/GetUserProfile', {UserId}).subscribe((response: any) => {console.log(response.data);
            this.updateUserProfileDetails(response.data);
        });
    }

    updateUserProfileDetails(user_: User) {
        const user: User = this.userService.getUser();

        user.city = user_.city;
        user.age = user_.age;
        user.country = user_.country;
        user.hobbies = user_.hobbies;

        this.userService.setUser(user);


    }

    addHobby(hobby_: any) {
        const user: User = this.userService.getUser();

        user.hobbies?.push(hobby_);

        this.userService.setUser(user);
    }

    removeHobby(hobbyId_: any) {
        const user: User = this.userService.getUser();
        if(user.hobbies) {
            const index = user.hobbies.findIndex(item => item.id == hobbyId_);
            if(index != -1) {
                user.hobbies.splice(index, 1);
                this.userService.setUser(user);
            }
        }
    }

    updateCity(name: string): void {

    }

    updateCountry(name: string): void {

    }

}
