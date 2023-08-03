import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { SearchUserParams } from 'src/app/shared/models/searchUsers/SearchUserParams';
import { FilteredMembersRequestService } from '../../members-list/services/filtered-members-request.service';
import { SearchBarService } from '../services/search-bar.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: [ './search-bar.component.scss' ],
})
export class SearchBarComponent implements OnInit {

  searchUserParams?: SearchUserParams;

  members: Member[] = [];

  genderList = [ { value: '1', display: 'Males' }, { value: '0', display: 'Females' } ];

  constructor(
    private searchBarService: SearchBarService,
    private filteredMembersRequestService: FilteredMembersRequestService,
  ) { }

  ngOnInit(): void {
    this.searchBarService.getSearchUserParams$()
      .subscribe((params_: SearchUserParams) => {
        this.searchUserParams = params_;
      });

    this.loadMembers();
  }

  loadMembers(): void {
    this.filteredMembersRequestService.loadMembers();
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
