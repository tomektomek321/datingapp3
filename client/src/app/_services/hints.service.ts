import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HintsService {

    showCitiesHintsUrl: string = environment.apiUrl + 'City/searchByText?_searchText='
    showCountriesHintsUrl: string = environment.apiUrl + 'Country/searchByText?_searchText='
    showHobbiesHintsUrl: string = environment.apiUrl + 'Hobby/searchByText/'

    constructor(
        private http: HttpClient
    ) { }

    showCitiesHints = (text: string) => this.http.get(this.showCitiesHintsUrl + text)

    showCountriesHints = (text: string) => this.http.get(this.showCountriesHintsUrl + text)

    showHobbiesHints = (text: string) => this.http.get(this.showHobbiesHintsUrl + text)
}
