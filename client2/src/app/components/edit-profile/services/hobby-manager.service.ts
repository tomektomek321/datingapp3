import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { HttpResponse } from 'src/app/shared/models/http/HttpResponse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HobbyManagerService {

    addHobbyURL: string = environment.apiUrl + 'UserHobby/AddUserHobby'
    removeHobbyURL: string = environment.apiUrl + 'UserHobby/RemoveUserHobby'
    getHobbyHintsURL: string = environment.apiUrl + 'editprofile/'


    constructor(
        private http: HttpClient,
        // private toastr: ToastrService,
    ) { }

    showHobbyHints = (text: string) => this.http.get(this.getHobbyHintsURL + text)

    addHobby(hobbyId: number, userId: number) {
        return this.http.post(this.addHobbyURL, {
            'UserId' : userId,
            'HobbyId': hobbyId,
        }).pipe(
            map((response: any) => {
                if(!response.success) {
                    //this.toastr.error(response.message);
                    console.log(response.message);
                }
                return response
            })
        )
    }

    removeHobby(hobbyId: number, userId: number) {
        return this.http.post(this.removeHobbyURL, {
            'UserId' : userId,
            'HobbyId': hobbyId,
        }).pipe(
            map((response: any) => {
                if(!response.success) {
                    //this.toastr.info(response.message);
                    console.log(response.message);
                }
                return response
            })
        )
    }
}
