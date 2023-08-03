import { Component, Input } from '@angular/core';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { Member } from 'src/app/shared/models/Member';
import { RateMemberManagerService } from '../../likes-list/services/rate-member-manager.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: [ './member-card.component.scss' ],
})
export class MemberCardComponent {

  @Input() member!: Member;

  constructor(
    private userManagerService: UserManagerService,
    private rateMemberManagerService: RateMemberManagerService,
  ) { }

  toggleLike(isLiked: boolean) {
    this.rateMemberManagerService.toggleLike(this.member.id, isLiked);
  }

  isLikedByUser = (): string => this.userManagerService.isLikedByUser(this.member.id) ? 'btn-success' : 'btn-primary';
}
