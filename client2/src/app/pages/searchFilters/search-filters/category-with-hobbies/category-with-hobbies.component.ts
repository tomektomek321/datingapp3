import { Component, Input } from '@angular/core';
import { CategoryRs, HobbyRs } from '../../models/myFilterSettings/MyFilterSettings';

@Component({
  selector: 'app-category-with-hobbies',
  templateUrl: './category-with-hobbies.component.html',
  styleUrls: [ './category-with-hobbies.component.scss' ],
})
export class CategoryWithHobbiesComponent {
  @Input() category!: CategoryRs;
  @Input() userHobbies!: HobbyRs[];
}
