import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HobbyService {

    constructor(
        private http: HttpClient,
        ) { }

    showHobbyHints = (text: string) => this.http.get(environment.apiUrl + 'editprofile/' + text)

    addHobby(hobby, username) { console.log(5)
        return this.http.post(environment.apiUrl + 'editprofile/addhobby', {
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
        return this.http.post(environment.apiUrl + 'editprofile/removeHobby', {
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
