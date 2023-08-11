import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { SearchFilterRqService } from '../services/search-filter-rq.service';
import { SearchFilterService } from '../services/search-filter.service';
import { SearchUserParams } from '../models/SearchUserParams';
import { FilteredMembersGatewayService } from '../gateway/filtered-members-gateway.service';
import { CategoryRs, HobbyRs, MyFilterSettingsRs } from '../models/myFilterSettings/MyFilterSettings';

@Component({
  selector: 'app-search-filters',
  templateUrl: './search-filters.component.html',
  styleUrls: [ './search-filters.component.scss' ],
})
export class SearchFiltersComponent implements OnInit {
  searchUserParams?: SearchUserParams;

  members: Member[] = [];

  categoriesWithHobbies?: CategoryRs[];

  userHobbies: HobbyRs[] = [];

  genderList = [
    { value: '1', display: 'Males' },
    { value: '0', display: 'Females' },
  ];

  constructor(
    private searchFilterRqService: SearchFilterRqService,
    private searchBarService: SearchFilterService,
    private filteredMembersGatewayService: FilteredMembersGatewayService,
  ) { }

  ngOnInit(): void {
    this.searchBarService.getSearchUserParams$()
      .subscribe((params_: SearchUserParams) => {
        this.searchUserParams = params_;
      });

    this.filteredMembersGatewayService.getMyFilterSettings()
      .subscribe((resp: MyFilterSettingsRs) => {
        console.log(resp);
        this.categoriesWithHobbies = resp.categoriesWithHobbies;
      });

    // this.loadMembers();
  }

  loadMembers(): void {
    this.searchFilterRqService.loadMembers();
  }

  addCity(city_: any): void {
    if (this.searchUserParams) {
      this.searchBarService.addCity(city_);
    }
  }

  removeCity(city_: any) {
    this.searchBarService.removeCity(city_);
  }

  addHobby(city_: any): void {
    if (this.searchUserParams) {
      this.searchBarService.addHobby(city_);
    }
  }

  removeHobby(city_: any) {
    this.searchBarService.removeHobby(city_);
  }

  getNumberOfCities(): number {
    return this.searchBarService.getNumberOfCities();
  }

  getNumberOfHobbies(): number {
    return this.searchBarService.getNumberOfHobbies();
  }

  closeListOfCities() { this.searchBarService.closeListOfCities(); }

  closeListOfHobbies() { this.searchBarService.closeListOfHobbies(); }

  openListOfCities() { this.searchBarService.openListOfCities(); }

  openListOfHobbies() { this.searchBarService.openListOfHobbies(); }

  isListOfCitiesVisible = () => this.searchBarService.isListOfCitiesVisible();

  isListOfHobbiesVisible = () => this.searchBarService.isListOfHobbiesVisible();
}
