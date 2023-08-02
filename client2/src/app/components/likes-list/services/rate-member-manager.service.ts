import { Injectable } from '@angular/core';
import { LikesGatewayService } from 'src/app/domains/likes/likes-gateway.service';
import { UserService } from 'src/app/infrastructure/identity/user.service';
import { FilteredMembersService } from './filtered-members.service';

@Injectable({
  providedIn: 'root'
})
export class RateMemberManagerService {

  constructor(
    private userService: UserService,
    private likesGatewayService: LikesGatewayService,
    private filteredMembersService: FilteredMembersService,
  ) { }

  toggleLike(memberId: number): void {
    const user = this.userService.getUser();
    const userId = user.id;

    this.likesGatewayService.likeMember({
      sourceUserId: userId,
      targetUserId: memberId
    }).subscribe((response: any) => {
      if (response.success) {
        const members = this.filteredMembersService.getFilteredMembers();
        members.shift();
        this.filteredMembersService.setFilteredMembers(members);
        //this.toastr.success("Userlike toggled");
      } else {
        //this.toastr.error("Something bad happened.");
      }
    })
  }
}
