import { Component, Input, OnInit } from '@angular/core';
import { CategoryRs } from '../../models/myFilterSettings/MyFilterSettings';

@Component({
  selector: 'app-category-with-hobbies',
  templateUrl: './category-with-hobbies.component.html',
  styleUrls: [ './category-with-hobbies.component.scss' ],
})
export class CategoryWithHobbiesComponent implements OnInit {
  @Input() category!: CategoryRs;

  constructor() { }

  ngOnInit(): void {
    console.log(this.category);
  }
}
