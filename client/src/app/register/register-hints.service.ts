import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class RegisterHintsService {

    showCitiesHintsUrl: string = environment.apiUrl + 'account/hintsForCities/'
    showCountriesHintsUrl: string = environment.apiUrl + 'account/hintsForCountries/'

    constructor(
        private http: HttpClient
    ) { }

    showCitiesHints = (text: string) => this.http.get(this.showCitiesHintsUrl + text)

    showCountriesHints = (text: string) => this.http.get(this.showCountriesHintsUrl + text)

}
