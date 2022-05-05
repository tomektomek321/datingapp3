import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Member, UserHobbies } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
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
    hobbyToAdd: string;
    hobbyToAddObject: UserHobbies;

    allHobbiesNames: any = [];
    hobbiesNamesPromptsShow = false;
    companiesNamesPrompts: any = [];


    @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
        if (this.editForm.dirty) {
            $event.returnValue = true;
        }
    }

    constructor(
        private userService: UserService,
        private accountService: AccountService,
        private memberService: MembersService,
        private toastr: ToastrService,
        private hobbyService: HobbyService
    ) {  }

    ngOnInit(): void {
        this.loadMember();

        this.userService.getUserObs().subscribe(user => {
            this.user = user;
        });
    }

    loadMember(): void {
        this.memberService.GetUserDetails();
    }

    updateMember(): void {
        this.memberService.updateMember(this.user);
    }

    removeUsedHobbies(allHobbies) {
        const allIds = allHobbies.map(item => item.name);
        const userHobbiesIds = this.member.userHobbies.map(item => item.name);
        const toShow = allIds.filter(item => !userHobbiesIds.includes(item));
        const a = allHobbies.filter(item => toShow.includes(item.name));
        return a;
    }

    addHobby(): void {
        let userId = this.userService.getUser().id

        this.hobbyService.addHobby(this.hobbyToAddObject.id, userId)
        .subscribe((response: boolean) => {
            if(response) {
                this.user.hobbies.push(this.hobbyToAddObject);
                this.updateMember();
            }
        })
    }

    removeHobby(hobbyId: number): void {
        let userId = this.userService.getUser().id

        this.hobbyService.removeHobby(hobbyId, userId)
        .subscribe((response: boolean) => {
            if(response) {
                const index = this.user.hobbies.findIndex(item => item.id == hobbyId);
                this.user.hobbies.splice(index, 1);
                this.updateMember();
            }
        });
    }

    getValue($event): void {
        this.hobbyToAddObject = $event;
        this.addHobby();
    }
}
