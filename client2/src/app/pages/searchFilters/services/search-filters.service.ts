import { Injectable } from '@angular/core';
import { SearchUserParams } from '../models/SearchUserParams';
import { SearchUserOrderByEnum } from '../models/SearchUserOrderByEnum';
import { BehaviorSubject } from 'rxjs';
import { CategoryRs } from '../models/myFilterSettings/MyFilterSettings';

@Injectable({
  providedIn: 'root',
})
export class SearchFiltersService {
  searchUserParams: SearchUserParams = {
    gender: 0,
    minAge: 21,
    maxAge: 23,
    cities: [],
    hobbies: [],
    orderBy: SearchUserOrderByEnum.lastActive,
  };

  searchFiltersData: CategoryRs[] = [];

  listOfCitiesVisible = false;

  listOfHobbiesVisible = false;

  searchUserParams$ = new BehaviorSubject<SearchUserParams>(
    this.searchUserParams,
  );

  constructor() {}

  getSearchUserParams = (): SearchUserParams => this.searchUserParams;

  getSearchUserParams$ = () => this.searchUserParams$.asObservable();

  getNumberOfCities = () => this.searchUserParams.cities.length;

  getNumberOfHobbies = () => this.searchUserParams.hobbies.length;

  closeListOfCities() {
    this.listOfCitiesVisible = false;
  }

  closeListOfHobbies() {
    this.listOfHobbiesVisible = false;
  }

  openListOfCities() {
    this.listOfHobbiesVisible = false;
    this.listOfCitiesVisible = true;
  }

  openListOfHobbies() {
    this.listOfCitiesVisible = false;
    this.listOfHobbiesVisible = true;
  }

  isListOfCitiesVisible = () => this.listOfCitiesVisible;

  isListOfHobbiesVisible = () => this.listOfHobbiesVisible;
}
