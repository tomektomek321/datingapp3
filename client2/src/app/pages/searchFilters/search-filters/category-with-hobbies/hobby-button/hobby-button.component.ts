import { Component, Input } from '@angular/core';
import { HobbyRs } from '../../../models/myFilterSettings/MyFilterSettings';
import { SearchFilterRqService } from '../../../services/search-filter-rq.service';
import { SearchFiltersService } from '../../../services/search-filters.service';
import { IdName } from 'src/app/shared/models/IdName';

@Component({
  selector: 'app-hobby-button',
  templateUrl: './hobby-button.component.html',
  styleUrls: [ './hobby-button.component.scss' ],
})
export class HobbyButtonComponent {
  @Input() hobby!: HobbyRs;
  constructor(
    private readonly searchFilterRqService: SearchFilterRqService,
    private readonly searchFiltersService: SearchFiltersService,
  ) { }

  toggle() {
    this.searchFilterRqService.toggleHobby(this.hobby.id);
  }

  isHobbySelected(): boolean {
    const state = this.searchFiltersService.getSearchUserParams();
    const hobby = state.hobbies.find((h: IdName) => h.id === this.hobby.id);
    const isSelected = !!hobby;

    return isSelected;
  }
}
