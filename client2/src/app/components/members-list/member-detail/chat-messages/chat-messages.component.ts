import { Component, Input, OnInit } from '@angular/core';
import { Message } from 'src/app/shared/models/Message';
import { MessagesManagerService } from '../../services/messages-manager.service';

@Component({
  selector: 'app-chat-messages',
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent implements OnInit {

    @Input('username') username?: string;

    messages: Message[] = [];

    constructor(
        private messagesManagerService: MessagesManagerService,
    ) {

    }

    ngOnInit(): void {
        if(this.username) {
            this.messagesManagerService.getMessageThread(this.username).subscribe( (response: any) => { console.log(response);
                this.messages = response.data;
            });
        }
    }

}
