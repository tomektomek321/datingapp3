import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IdName } from '../../models/IdName';

@Component({
    selector: 'app-badge-item',
    templateUrl: './badge-item.component.html',
    styleUrls: ['./badge-item.component.scss']
})
export class BadgeItemComponent implements OnInit {

    @Input('item') item!: IdName;

    @Output() callback = new EventEmitter<any>();

    constructor() { }

    ngOnInit(): void { }

    remove() {
        this.callback.emit(this.item);
    }

}
