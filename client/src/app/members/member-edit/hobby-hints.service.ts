import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { env } from 'process';
import { map } from 'rxjs/operators';
import { HttpResponse } from 'src/app/_models/HttpResponse';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HobbyService {

    addHobbyURL: string = environment.apiUrl + 'UserHobby/AddUserHobby'
    removeHobbyURL: string = environment.apiUrl + 'UserHobby/RemoveUserHobby'
    getHobbyHintsURL: string = environment.apiUrl + 'editprofile/'

    constructor(
        private http: HttpClient,
        private toastr: ToastrService,
    ) { }

    showHobbyHints = (text: string) => this.http.get(this.getHobbyHintsURL + text)

    addHobby(hobbyId, userId) {
        return this.http.post(this.addHobbyURL, {
            'UserId' : userId,
            'HobbyId': hobbyId,
        }).pipe(
            map((response: HttpResponse<number>) => {
                if(!response.success) {
                    this.toastr.error(response.message);
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
            map((response: HttpResponse<number>) => {
                if(!response.success) {
                    this.toastr.info(response.message);
                }
                return response
            })
        )
    }
}
