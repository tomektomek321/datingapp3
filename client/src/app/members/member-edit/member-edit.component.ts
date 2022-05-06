import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { HttpResponse } from 'src/app/_models/HttpResponse';
import { Member, UserHobbies } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { UserProfilaService } from 'src/app/_services/user-profila.service';
import { UserService } from 'src/app/_services/user.service';
import { HobbyService } from './hobby-hints.service';

@Component({
    selector: 'app-member-edit',
    templateUrl: './member-edit.component.html',
    styleUrls: ['./member-edit.component.scss']
})
export class MemberEditComponent implements OnInit {

    @ViewChild('editForm') editForm: NgForm;

    member: Member;

    user: User;

    @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
        if (this.editForm.dirty) {
            $event.returnValue = true;
        }
    }

    constructor(
        private userService: UserService,
        private memberService: MembersService,
        private hobbyService: HobbyService,
        private userProfileService: UserProfilaService,
    ) {  }


    ngOnInit(): void {
        this.memberService.GetUserDetails();

        this.userService.getUserObs().subscribe(user => {
            this.user = user;
        });
    }

    removeUsedHobbies(allHobbies) {
        const allIds = allHobbies.map(item => item.name);
        const userHobbiesIds = this.member.userHobbies.map(item => item.name);
        const toShow = allIds.filter(item => !userHobbiesIds.includes(item));
        const a = allHobbies.filter(item => toShow.includes(item.name));
        return a;
    }

    getHobby(hobbyObject): void {
        this.addHobby(hobbyObject);
    }

    addHobby(hobbyObject): void {
        let userId = this.userService.getUser().id

        this.hobbyService.addHobby(hobbyObject.id, userId).subscribe((response: HttpResponse<number>) => {
            console.log(response)
            if(response.success) {
                this.user.hobbies.push(hobbyObject);
            }
        })
    }

    removeHobby(hobbyId: number): void {
        let userId = this.userService.getUser().id

        this.hobbyService.removeHobby(hobbyId, userId).subscribe((response: HttpResponse<number>) => {
            if(response) {
                const index = this.user.hobbies.findIndex(item => item.id == hobbyId);
                this.user.hobbies.splice(index, 1);
            }
        });
    }

    getCity(cityObject): void {
        this.changeCity(cityObject);
    }


    changeCity(cityObject) {
        this.userProfileService.updateCity(cityObject);









    }





    getCountry(cityObject): void {
        this.changeCity(cityObject);
    }





}
