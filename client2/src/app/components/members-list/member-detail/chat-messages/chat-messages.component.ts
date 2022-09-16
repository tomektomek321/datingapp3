import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Message } from 'src/app/shared/models/Message';
import { MessagesManagerService } from '../../services/messages-manager.service';

@Component({
  selector: 'app-chat-messages',
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent implements OnInit {

    @ViewChild('messageForm') messageForm?: NgForm;

    @Input('username') username?: string;

    messageContent?: string;

    messages: Message[] = [];

    constructor(
        private messagesManagerService: MessagesManagerService,
    ) {

    }

    ngOnInit(): void {
        if(this.username) {
            this.messagesManagerService.getMessageThread(this.username).subscribe( (response: any) => {
                this.messages = response.data;
            });
        }
    }

    sendMessage() {

        if(this.username && this.messageContent) {
            this.messagesManagerService.sendMessage(this.username, this.messageContent).subscribe((message: any) => {debugger
                if(this.messageContent) {
                    this.messages.push(message.data);
                }
                this.messageForm && this.messageForm.reset();
            });

        }
    }

}
