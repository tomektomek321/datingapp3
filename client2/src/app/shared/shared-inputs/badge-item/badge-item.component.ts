import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IdName } from '../../models/IdName';

@Component({
    selector: 'app-badge-item',
    templateUrl: './badge-item.component.html',
    styleUrls: ['./badge-item.component.scss']
})
export class BadgeItemComponent implements OnInit {

    @Input('city_') city_!: IdName

    @Output() callback = new EventEmitter<any>();

    constructor() { }

    ngOnInit(): void {

    }

    remove() {
        this.callback.emit(this.city_);
    }

}
