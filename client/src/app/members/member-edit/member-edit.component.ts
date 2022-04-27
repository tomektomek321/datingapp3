import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
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
    hobbyToAdd: string
    hobbyToAddObject: UserHobbies

    allHobbiesNames: any = []
    hobbiesNamesPromptsShow = false
    companiesNamesPrompts: any = []


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
        private hobbyService: HobbyService) {

    }

    ngOnInit(): void {
        this.userService.getUserObs().subscribe(user => {
            this.user = user
            console.log(user)
            this.loadMember()
        });
    }

    loadMember() {
        this.memberService.getMember(this.user.username).subscribe(member => {
            console.log(member)
            this.member = member;
        })
    }

    updateMember() {
        this.memberService.updateMember(this.member).subscribe(() => {
            this.toastr.success('Profile updated successfully');
            this.editForm.reset(this.member);
        })
    }

    removeUsedHobbies(allHobbies) {
        const allIds = allHobbies.map(item => item.name)
        const userHobbiesIds = this.member.userHobbies.map(item => item.name)
        const toShow = allIds.filter(item => !userHobbiesIds.includes(item))
        const a = allHobbies.filter(item => toShow.includes(item.name))
        return a;
    }

    showHobbyHint() {
        this.hobbyService.showHobbyHints(this.hobbyToAdd).subscribe( response => {
            console.log(response)
            this.allHobbiesNames = this.removeUsedHobbies(response)
            this.showCompaniesPrompt()
        })
    }

    showCompaniesPrompt() {

        this.hobbiesNamesPromptsShow = true

        /*console.log(this.model.Manufacturer)
        console.log(this.allHobbiesNames)
        if(this.model.Manufacturer.length == 0) {
          this.companiesNamesPrompts = this.allHobbiesNames
        } else {
          this.companiesNamesPrompts = Object.values(this.allHobbiesNames)
                                          .filter((c: any) => { console.log(c); return c.toLowerCase().includes(this.model.Manufacturer.toLowerCase())} )
        }

        this.companiesNamesPromptsShow = true*/
      }

    selectCompany(hobby_: any) {
        this.hobbiesNamesPromptsShow = false

        this.hobbyToAdd = hobby_.name
        this.hobbyToAddObject = hobby_
    }

    test(hobby_) {
        console.log(hobby_)
    }

    addHobby() {
        let user = this.accountService.currentUser$;
        console.log(user)
        this.hobbyService.addHobby(this.hobbyToAddObject, this.accountService.getUser().username)
        .subscribe((response: boolean) => {
            if(response) {
                this.member.userHobbies.push(this.hobbyToAddObject)
                this.updateMember()
            }
        })

    }

    removeHobby(hobby) {

        let user = this.accountService.currentUser$;
        console.log(user)
        this.hobbyService.removeHobby(hobby, this.accountService.getUser().username)
        .subscribe((response: boolean) => {
            if(response) {
                const index = this.member.userHobbies.findIndex(item => item.id == hobby.id)
                this.member.userHobbies.splice(index, 1)
                this.updateMember()
            }
        })


    }

}
