import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';

@Component({
    selector: 'app-member-card',
    templateUrl: './member-card.component.html',
    styleUrls: ['./member-card.component.scss']
})
export class MemberCardComponent implements OnInit {

    @Input() member!: Member;

    constructor() { }

    ngOnInit(): void { }
}
