import { Component, Input, OnInit } from '@angular/core';
import { HobbyRs } from '../../../models/myFilterSettings/MyFilterSettings';

@Component({
  selector: 'app-hobby-button',
  templateUrl: './hobby-button.component.html',
  styleUrls: [ './hobby-button.component.scss' ],
})
export class HobbyButtonComponent implements OnInit {
  @Input() hobby!: HobbyRs;
  constructor() { }

  ngOnInit(): void {

  }
}
