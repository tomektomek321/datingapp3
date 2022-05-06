import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TextInputWithHintsComponent } from '../text-input-with-hints.component';

@Component({
  selector: 'app-hints-for-input',
  templateUrl: './hints-for-input.component.html',
  styleUrls: ['./hints-for-input.component.scss']
})
export class HintsForInputComponent extends TextInputWithHintsComponent {

    constructor(protected http: HttpClient) {
        super(http);
    }
}
