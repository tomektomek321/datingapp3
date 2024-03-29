import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, EventEmitter, HostListener, Input, OnInit, Output, ViewChild } from '@angular/core';
import { fromEvent } from 'rxjs';
import { debounceTime, pluck } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

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

  @ViewChild('textInput') textInput!: ElementRef;

  @Input('URL') URL!: string;

  @Input('autoAdd') autoAdd: boolean = false;

  @Input('setValueToInput') setValueToInput: boolean = false;

  @Input('valueInput') valueInput: undefined | string = "";

  @Input('placeholder') placeholder: string = "";

  @Input('label') label: string | false = false;

  @Input('fullWidth') fullWidth: boolean = true;

  @Input('labelWidth') labelWidth: string | undefined = "auto";

  @Input('darkMode') darkMode: boolean = false;

  @Output() callback = new EventEmitter<IdName>();

  allItems: IdName[] = [];

  inputValue!: null | string;

  itemToAdd!: null | string;

  itemToAddObject!: IdName;

  promptShow: boolean = false;

  constructor(
    protected http: HttpClient,
  ) { }

  ngOnInit(): void { }

  ngAfterViewInit(): void {
    fromEvent(this.textInput.nativeElement, 'input').pipe(
      pluck("target", "value"),
      debounceTime(400),
    ).subscribe((data: any) => {
      this.request();
    })
  }

  @HostListener('window:click', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (this.promptShow)
      this.promptShow = false;
  }

  request(): void {
    const url = environment.apiUrl + this.URL + this.valueInput;

    this.http.get(url).subscribe((response: any) => {
      this.allItems = response.data;
      this.promptShow = true;
    })
  }

  setValue(value_: any): void {

    this.promptShow = false;
    this.itemToAdd = value_.name;
    this.itemToAddObject = value_;
    if (this.setValueToInput) {
      this.valueInput = value_.name;
    }

    if (this.autoAdd) {
      this.callback.emit(this.itemToAddObject);
      this.itemToAdd = null;
    }
  }

  addValue(): void {
    this.callback.emit(this.itemToAddObject);
  }

  getCSS(): string {
    let response = "";
    if (this.fullWidth) { response += "fullWidth" }


    return response;
  }

  getLabelWidth() {
    return this.labelWidth;
  }

}
