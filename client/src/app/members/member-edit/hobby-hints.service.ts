import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
        this.http.post(environment.apiUrl + 'editprofile/addhobby', {
            'hobbyId': hobby.id,
            'hobbyname': hobby.name,
            'username' : username
        }).subscribe((response: boolean) => {
            console.log(response)
            if(response) {

            }
        })
    }
}
