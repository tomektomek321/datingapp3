import { Injectable } from '@angular/core';
import { IdName } from 'src/app/shared/models/IdName';
import { SearchUserOrderByEnum } from '../models/SearchUserOrderByEnum';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { SearchFiltersService } from './search-filters.service';
import { AppUser } from 'src/app/shared/models/identity/AppUser';
import { SearchUserParams } from '../models/SearchUserParams';
import { MyFilterSettingsRs } from '../models/myFilterSettings/MyFilterSettings';

@Injectable({
  providedIn: 'root',
})
export class SearchFiltersManagerService {
  constructor(
    private readonly userService: UserService,
    private readonly searchFiltersService: SearchFiltersService,
  ) {
    this.userService.getUser$().subscribe((user: AppUser) => {
      if (user.id && user.gender !== undefined) {
        const searchFilters = this.searchFiltersService.getSearchUserParams();
        searchFilters.gender = user.gender.toString() == '1' ? 0 : 1;
        this.searchFiltersService.searchUserParams$.next(searchFilters);
      }
    });
  }

  initFilterSettings(settings: MyFilterSettingsRs): void {
    const searchFilters = this.searchFiltersService.getSearchUserParams();

    searchFilters.hobbies = settings.userHobbies;

    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }

  addCity(city_: IdName): void {
    const searchFilters = this.searchFiltersService.getSearchUserParams();

    const added = searchFilters.cities.filter(
      (item) => item.id == city_.id,
    );

    if (added.length > 0) {
      console.log('Already added');

      return;
    }

    searchFilters.cities.push(city_);
    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }

  removeCity(city_: IdName): void {
    const searchFilters = this.searchFiltersService.getSearchUserParams();

    const added = searchFilters.cities.filter(
      (item) => item.id != city_.id,
    );

    // if (added.length == 0) {
    //   this.listOfCitiesVisible = false;
    // }

    searchFilters.cities = added;
    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }

  addHobby(city_: IdName): void {
    const searchFilters = this.searchFiltersService.getSearchUserParams();

    const added = searchFilters.hobbies.filter(
      (item: IdName) => item.id == city_.id,
    );

    if (added.length > 0) {
      return;
    }

    searchFilters.hobbies.push(city_);
    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }

  removeHobby(city_: IdName): void {
    const searchFilters = this.searchFiltersService.getSearchUserParams();

    const added = searchFilters.hobbies.filter(
      (item) => item.id != city_.id,
    );

    searchFilters.hobbies = added;
    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }

  toggleHobby(city_: IdName) {
    const searchFilters = this.searchFiltersService.getSearchUserParams();

    const added = searchFilters.hobbies.filter(
      (item: IdName) => item.id == city_.id,
    );

    if (added.length > 0) {
      searchFilters.hobbies = searchFilters.hobbies.filter(
        (item: IdName) => item.id != city_.id,
      );
    } else {
      searchFilters.hobbies.push(city_);
    }

    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }

  resetParams(): void {
    let searchFilters: SearchUserParams = this.searchFiltersService.getSearchUserParams();

    searchFilters = {
      gender: 1,
      minAge: 18,
      maxAge: 50,
      cities: [],
      hobbies: [],
      orderBy: SearchUserOrderByEnum.lastActive,
    };

    this.searchFiltersService.searchUserParams$.next(searchFilters);
  }
}
