import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { HttpResponse } from '../_models/HttpResponse';
import { UserService } from './user.service';

@Injectable({
    providedIn: 'root'
})
export class UserProfilaService {
    baseUrl = environment.apiUrl;

    updateCityURL = 'Member/UpdateUserProfileCity'
    updateCountryURL = 'Member/UpdateUserProfileCountry'

    constructor(
        private http: HttpClient,
        private userService: UserService,
        private toastr: ToastrService,
    ) { }

    updateCity(cityObject) {
        const userId = this.userService.getUser();

        this.http.post(this.baseUrl + this.updateCityURL, {
            userId: userId.id,
            cityId: cityObject.id,
        }).subscribe((response: HttpResponse<number>) => {
            if(response.success) {
                this.toastr.success("City Updated");
                this.userService.updateCity(cityObject.name);
            } else {
                this.toastr.error("Can't update City");
            }
        })
    }

    updateCountry(countryObject) {
        const userId = this.userService.getUser().id;

        this.http.post(this.baseUrl + this.updateCountryURL, {
            userId: userId,
            countryId: countryObject.id,
        }).subscribe((response: HttpResponse<number>) => {
            if(response.success) {
                this.toastr.success("Country Updated");
                this.userService.updateCountry(countryObject.name);
            } else {
                this.toastr.error("Can't update Country");
            }

        })
    }

}
