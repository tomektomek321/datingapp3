import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MessagesManagerService } from '../../services/messages-manager.service';

@Component({
  selector: 'app-chat-messages',
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent implements OnInit {

    constructor(
        private messagesManagerService: MessagesManagerService,
    ) {

    }

    ngOnInit(): void {

    }

}
