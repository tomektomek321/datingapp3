import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserProfileManagerService {

    updateCityURL = 'Member/UpdateUserProfileCity'
    updateCountryURL = 'Member/UpdateUserProfileCountry'

    constructor(
        private userManagerService: UserManagerService,
        private userService: UserService,
        private http: HttpClient,
    ) { }

    updateCity(cityObject: any) {
        const userId = this.userService.getUser();

        this.http.post(environment.apiUrl + this.updateCityURL, {
            userId: userId.id,
            cityId: cityObject.id,
        }).subscribe((response: any) => { debugger
            if(response.success) {
                //this.toastr.success("City Updated");
                this.userManagerService.updateCity(cityObject);
            } else {
                //this.toastr.error("Can't update City");
            }
        })
    }

    updateCountry(countryObject: any) {
        const userId = this.userService.getUser().id;

        this.http.post(environment.apiUrl + this.updateCountryURL, {
            userId: userId,
            countryId: countryObject.id,
        }).subscribe((response: any) => {
            if(response.success) {
                //this.toastr.success("Country Updated");
                this.userManagerService.updateCountry(countryObject);
            } else {
                //this.toastr.error("Can't update Country");
            }

        })
    }
}
