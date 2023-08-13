import { Component, OnInit } from '@angular/core';
import { SearchFilterRqService } from '../services/search-filter-rq.service';
import { SearchUserParams } from '../models/SearchUserParams';
import { CategoryRs, HobbyRs, MyFilterSettingsRs } from '../models/myFilterSettings/MyFilterSettings';
import { SearchFiltersService } from '../services/search-filters.service';
import { SearchFiltersManagerService } from '../services/search-filters-manager.service';

@Component({
  selector: 'app-search-filters',
  templateUrl: './search-filters.component.html',
  styleUrls: [ './search-filters.component.scss' ],
})
export class SearchFiltersComponent implements OnInit {
  searchUserParams?: SearchUserParams;

  categoriesWithHobbies?: CategoryRs[];

  userHobbies: HobbyRs[] = [];

  genderList = [
    { value: '1', display: 'Males' },
    { value: '0', display: 'Females' },
  ];

  constructor(
    private searchFilterRqService: SearchFilterRqService,
    private searchFiltersManagerService: SearchFiltersManagerService,
    private searchFiltersService: SearchFiltersService,
  ) { }

  ngOnInit(): void {
    this.searchFiltersService.getSearchUserParams$()
      .subscribe((params_: SearchUserParams) => {
        this.searchUserParams = params_;
      });

    this.searchFilterRqService.getMyFilterSettings()
      .subscribe((settings: MyFilterSettingsRs) => {
        this.searchFiltersManagerService.initFilterSettings(settings);
        this.categoriesWithHobbies = settings.categoriesWithHobbies;
      });

    // this.filteredMembersGatewayService.getMyFilterSettings()
    //   .subscribe((resp: MyFilterSettingsRs) => {
    //     console.log(resp);
    //     this.categoriesWithHobbies = resp.categoriesWithHobbies;
    //   });

    // this.loadMembers();
  }

  loadMembers(): void {
    this.searchFilterRqService.loadMembers();
  }

  addCity(city_: any): void {
    if (this.searchUserParams) {
      this.searchFiltersManagerService.addCity(city_);
    }
  }

  removeCity(city_: any) {
    this.searchFiltersManagerService.removeCity(city_);
  }

  addHobby(city_: any): void {
    if (this.searchUserParams) {
      this.searchFiltersManagerService.addHobby(city_);
    }
  }

  removeHobby(city_: any) {
    this.searchFiltersManagerService.removeHobby(city_);
  }

  getNumberOfCities(): number {
    return this.searchFiltersService.getNumberOfCities();
  }

  getNumberOfHobbies(): number {
    return this.searchFiltersService.getNumberOfHobbies();
  }

  closeListOfCities() { this.searchFiltersService.closeListOfCities(); }

  closeListOfHobbies() { this.searchFiltersService.closeListOfHobbies(); }

  openListOfCities() { this.searchFiltersService.openListOfCities(); }

  openListOfHobbies() { this.searchFiltersService.openListOfHobbies(); }

  isListOfCitiesVisible = () => this.searchFiltersService.isListOfCitiesVisible();

  isListOfHobbiesVisible = () => this.searchFiltersService.isListOfHobbiesVisible();
}
