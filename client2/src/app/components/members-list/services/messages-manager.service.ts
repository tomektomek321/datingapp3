import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { AppUser } from 'src/app/shared/models/identity/AppUser';
import { Message } from 'src/app/shared/models/Message';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MessagesManagerService {
  constructor(
    private http: HttpClient,
    private userService: UserService,
  ) { }

  getMessageThread(username: string) {
    const user: AppUser = this.userService.getUser();

    return this.http.post<Message[]>(environment.apiUrl + 'Messages/GetMessageThread', {
      currentUsername: user.username,
      recipientUsername: username,
    });
  }

  sendMessage(recipientUsername: string, content: string) {
    const user: AppUser = this.userService.getUser();

    if (user.username) {
      return this.http.post<Message>(
        environment.apiUrl + 'Messages/CreateMessage', { senderUsername: user.username, recipientUsername, content });
    } else {
      return new Observable();
    }
  }
}
