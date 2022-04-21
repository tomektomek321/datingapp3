import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from 'process';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HobbyService {

    addHobbyURL: string = environment.apiUrl + 'editprofile/addhobby'
    removeHobbyURL: string = environment.apiUrl + 'editprofile/removeHobby'
    getHobbyHintsURL: string = environment.apiUrl + 'editprofile/'

    constructor(
        private http: HttpClient,
        ) { }

    showHobbyHints = (text: string) => this.http.get(this.getHobbyHintsURL + text)

    addHobby(hobby, username) { console.log(5)
        return this.http.post(this.addHobbyURL, {
            'hobbyId': hobby.id,
            'hobbyname': hobby.name,
            'username' : username
        }).pipe(
            map(response => {
                return response
            })
        )
    }

    removeHobby(hobby, username) { console.log(6)
        return this.http.post(this.removeHobbyURL, {
            'hobbyId': hobby.id,
            'hobbyname': hobby.name,
            'username' : username
        }).pipe(
            map(response => {
                return response
            })
        )
    }
}
