import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
    selector: 'app-text-input-with-hints',
    templateUrl: './text-input-with-hints.component.html',
    styleUrls: ['./text-input-with-hints.component.scss']
})
export class TextInputWithHintsComponent implements OnInit {

    @Input('URL') URL: string;

    @Output() valueEmitter = new EventEmitter<{ id: number, name: string }>();

    allItems: { id: number, name: string }[] = [];

    inputValue: string;

    itemToAdd: string;
    itemToAddObject: { id: number, name: string };

    promptShow: boolean = false;


    constructor(
        private http: HttpClient,
    ) { }

    ngOnInit(): void {

    }

    getHints() {
        this.http.get(environment.apiUrl + this.URL + this.inputValue).subscribe( (response: { id: number, name: string }[]) => {
            console.log(response);
            this.allItems = response;
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
