import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpResponse } from '../_models/HttpResponse';

interface IdName {
    id: number;
    name: number;
}

@Component({
    selector: 'app-text-input-with-hints',
    templateUrl: './text-input-with-hints.component.html',
    styleUrls: ['./text-input-with-hints.component.scss']
})
export class TextInputWithHintsComponent implements OnInit {

    @Input('URL') URL: string;

    @Input('placeholder') placeholder: string;

    @Output() valueEmitter = new EventEmitter<IdName>();

    allItems: IdName[] = [];

    inputValue: string;

    itemToAdd: string;
    itemToAddObject: IdName;

    promptShow: boolean = false;


    constructor(
        private http: HttpClient,
    ) { }

    ngOnInit(): void {
        console.log(this.allItems)
    }

    getHints() {
        this.http.get(environment.apiUrl + this.URL + this.inputValue).subscribe( (response: HttpResponse<IdName[]>) => {
            console.log(response);
            this.allItems = response.data;
            this.promptShow = true;
        })
    }

    setValue(value_) {
        this.inputValue = value_.name;
        this.promptShow = false;
        this.itemToAdd = value_.name;
        this.itemToAddObject = value_;
    }

    addValue() {
        this.valueEmitter.emit(this.itemToAddObject);
    }

}
