import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
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
    hobbyToAddObject: object

    allHobbiesNames: any = []
    hobbiesNamesPromptsShow = false
    companiesNamesPrompts: any = []


    @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
        if (this.editForm.dirty) {
            $event.returnValue = true;
        }
    }

    constructor(
        private accountService: AccountService,
        private memberService: MembersService,
        private toastr: ToastrService,
        private hobbyService: HobbyService) {

    }

    ngOnInit(): void {
        this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
            this.user = user
            this.loadMember()
        });
    }

    loadMember() {
        this.memberService.getMember(this.user.userName).subscribe(member => {
            this.member = member;
        })
    }

    updateMember() {
        this.memberService.updateMember(this.member).subscribe(() => {
            this.toastr.success('Profile updated successfully');
            this.editForm.reset(this.member);
        })
    }

    showHobbyHint() {
        console.log(4)
        this.hobbyService.showHobbyHints(this.hobbyToAdd).subscribe( response => {
            console.log(response)
            this.allHobbiesNames = response
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
        this.hobbyService.addHobby(this.hobbyToAddObject, this.accountService.getUser().userName)
    }

}
