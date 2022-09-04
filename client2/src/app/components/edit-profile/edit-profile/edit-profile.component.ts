import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { User } from 'src/app/shared/models/identity/User';
import { IdName } from 'src/app/shared/models/IdName';
import { HobbyManagerService } from '../services/hobby-manager.service';
import { UserProfileManagerService } from '../services/user-profile-manager.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit, AfterViewInit {

    @ViewChild('editForm') editForm!: NgForm;

    user?: User;

    constructor(
        private userService: UserService,
        private userManagerService: UserManagerService,
        private hobbyManager: HobbyManagerService,
        private userProfileManagerService: UserProfileManagerService,
    ) {

    }
    ngAfterViewInit(): void {
        console.log(this.editForm)
    }

    ngOnInit(): void {
        console.log(this.editForm)
        this.userManagerService.GetUserDetails();

        this.userService.getUser$().subscribe((user: User) => {
            this.user = user;
        });
    }

    updateMember() {}
    removeHobby(hobbyId_: number) {
        let userId = this.userService.getUser().id

        this.hobbyManager.removeHobby(hobbyId_, userId).subscribe((response: any) => {
            if(response) {
                this.userManagerService.removeHobby(hobbyId_);
            }
        });
    }

    getHobby(hobbyObject: any): void {
        this.addHobby(hobbyObject);
    }

    addHobby(hobbyObject: any): void {
        let userId = this.userService.getUser().id

        this.hobbyManager.addHobby(hobbyObject.id, userId).subscribe((response: any) => {
            console.log(response)
            if(response.success) {
                this.userManagerService.addHobby(hobbyObject);
            };
        })
    }

    getCity(cityObject: any): void {
        this.changeCity(cityObject);
    }

    changeCity(cityObject: any): void {




        this.userProfileManagerService.updateCity(cityObject);
    }

    getCountry(cityObject: any): void {
        this.userProfileManagerService.updateCountry(cityObject);
    }
}
