import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { User } from 'src/app/shared/models/identity/User';
import { Message } from 'src/app/shared/models/Message';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class MessagesManagerService {

    baseUrl = environment.apiUrl;

    constructor(
        private http: HttpClient,
        private userService: UserService,
    ) { }

    getMessageThread(username: string) {
        const user: User =  this.userService.getUser();debugger

        return this.http.post<Message[]>(this.baseUrl + 'Messages/GetMessageThread', {
            currentUsername: user.username,
            recipientUsername: username,
        });

    }

}
