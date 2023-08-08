import { Component, Input } from '@angular/core';
import { RateMemberManagerService } from 'src/app/components/likes-list/services/rate-member-manager.service';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { Member } from 'src/app/shared/models/Member';

@Component({
  selector: 'app-rate-member-card',
  templateUrl: './rate-member-card.component.html',
  styleUrls: [ './rate-member-card.component.scss' ],
})
export class RateMemberCardComponent {
  @Input() member!: Member;
  constructor(
    private userManagerService: UserManagerService,
    private rateMemberManagerService: RateMemberManagerService,
  ) {
    console.log(this.member);
  }

  toggleLike(isLiked: boolean) {
    this.rateMemberManagerService.toggleLike(this.member.id, isLiked);
  }

  isLikedByUser = (): string => this.userManagerService.isLikedByUser(this.member.id) ? 'btn-success' : 'btn-primary';
}
