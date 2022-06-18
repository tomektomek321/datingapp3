import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { fromEvent } from 'rxjs';
import { debounceTime, pluck } from 'rxjs/operators';
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
export class TextInputWithHintsComponent implements OnInit, AfterViewInit {

    @ViewChild('textInput') textInput: ElementRef;

    @Input('URL') URL: string;

    @Input('autoAdd') autoAdd: boolean;

    @Input('setValueToInput') setValueToInput: boolean;

    @Input('valueInput') valueInput: string;

    @Input('placeholder') placeholder: string;

    @Output() callback = new EventEmitter<IdName>();

    allItems: IdName[] = [];

    inputValue: string;

    itemToAdd: string;

    itemToAddObject: IdName;

    promptShow: boolean = false;

    constructor(
        protected http: HttpClient,
    ) { }

    ngOnInit(): void {}

    ngAfterViewInit() {
        fromEvent(this.textInput.nativeElement, 'input').pipe(
            pluck("target", "value"),
            debounceTime(800),
        ).subscribe((data: KeyboardEvent) => {
            this.request()
        })
    }

    request() {
        const url = environment.apiUrl + this.URL + this.valueInput;

        this.http.get(url).subscribe( (response: HttpResponse<IdName[]>) => {
            this.allItems = response.data;
            this.promptShow = true;
        })
    }

    setValue(value_): void {

        this.promptShow = false;
        this.itemToAdd = value_.name;
        this.itemToAddObject = value_;
        if(this.setValueToInput) {
            this.valueInput = value_.name;
        }

        if(this.autoAdd) {
            this.callback.emit(this.itemToAddObject);
            this.valueInput = null;
            this.itemToAdd = null;
            this.itemToAddObject = null;
        }
    }

    addValue(): void {
        this.callback.emit(this.itemToAddObject);
    }

}
