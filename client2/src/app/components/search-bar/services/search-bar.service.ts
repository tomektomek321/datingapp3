import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { IdName } from 'src/app/shared/models/IdName';
import { User } from 'src/app/shared/models/identity/User';
import { SearchUserOrderByEnum } from 'src/app/shared/models/searchUsers/SearchUserOrderByEnum';
import { SearchUserParams } from 'src/app/shared/models/searchUsers/SearchUserParams';

@Injectable({
  providedIn: 'root',
})
export class SearchBarService {
  searchUserParams: SearchUserParams = {
    gender: 0,
    minAge: 32,
    maxAge: 37,
    cities: [/*
            { id: 1, name: 'Gdansk' },
            { id: 2, name: 'Warszawa' },
    */],
    hobbies: [],
    orderBy: SearchUserOrderByEnum.lastActive,
  };

  constructor(
    private readonly userService: UserService,
  ) {
    this.userService.getUser$().subscribe((user: User) => {
      if (user.id && user.gender !== undefined) {
        this.searchUserParams.gender = user.gender.toString() == '1' ? 0 : 1;
        this.searchUserParams$.next(this.searchUserParams);
      }
    });
  }

  listOfCitiesVisible = false;

  listOfHobbiesVisible = false;

  searchUserParams$ = new BehaviorSubject<SearchUserParams>(this.searchUserParams);

  getSearchUserParams = (): SearchUserParams => this.searchUserParams;

  getSearchUserParams$ = () => this.searchUserParams$.asObservable();

  addCity(city_: IdName): void {
    const added = this.searchUserParams.cities.filter(item => item.id == city_.id);

    if (added.length > 0) {
      console.log('Already added');

      return;
    }

    this.searchUserParams.cities.push(city_);
    this.searchUserParams$.next(this.searchUserParams);
  }

  removeCity(city_: IdName): void {
    const added = this.searchUserParams.cities.filter(item => item.id != city_.id);

    if (added.length == 0) {
      this.listOfCitiesVisible = false;
    }

    this.searchUserParams.cities = added;
    this.searchUserParams$.next(this.searchUserParams);
  }

  addHobby(city_: IdName): void {
    const added = this.searchUserParams.hobbies.filter(item => item.id == city_.id);

    if (added.length > 0) {
      console.log('Already added');

      return;
    }

    this.searchUserParams.hobbies.push(city_);
    this.searchUserParams$.next(this.searchUserParams);
  }

  removeHobby(city_: IdName): void {
    const added = this.searchUserParams.hobbies.filter(item => item.id != city_.id);

    if (added.length == 0) {
      this.listOfHobbiesVisible = false;
    }

    this.searchUserParams.hobbies = added;
    this.searchUserParams$.next(this.searchUserParams);
  }

  resetParams(): void {
    this.searchUserParams = {
      gender: 1,
      minAge: 18,
      maxAge: 50,
      cities: [],
      hobbies: [],
      orderBy: SearchUserOrderByEnum.lastActive,
    };

    this.searchUserParams$.next(this.searchUserParams);
  }

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
