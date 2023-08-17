import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-category-wallname',
  templateUrl: './category-wallname.component.html',
  styleUrls: [ './category-wallname.component.scss' ],
})
export class CategoryWallnameComponent {
  @Input() categoryName!: string;
}
