import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { User } from 'src/app/shared/models/identity/User';
import { HobbyManagerService } from '../services/hobby-manager.service';

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
    removeHobby(id_: number) {}

    getHobby(hobbyObject: any): void {
        this.addHobby(hobbyObject);
    }

    addHobby(hobbyObject: any): void {
        let userId = this.userService.getUser().id

        this.hobbyManager.addHobby(hobbyObject.id, userId).subscribe((response: any) => {
            console.log(response)
            if(response.success) {
                this.userManagerService.addHobby(hobbyObject);
                //this.user.hobbies.push(hobbyObject);
            };
        })
    }
}
