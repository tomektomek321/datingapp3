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
    console.log(user);

    this.likesGatewayService.likeMember({
      sourceUserId: userId,
      targetUserId: memberId
    }).subscribe((response: any) => {
      if (response.success) {
        // this.userManagerService.toggleLike(memberId);
        debugger;
        const members = this.filteredMembersService.getFilteredMembers();

        members.shift();

        this.filteredMembersService.setFilteredMembers(members);


        //this.toastr.success("Userlike toggled");
      } else {
        //this.toastr.error("Something bad happened.");
      }
    })

    /*this.http.post(environment.apiUrl + 'Like/LikeUser', {
      sourceUserId: userId,
      targetUserId: memberId
    }).subscribe((response: any) => {
      console.log(response)
      if (response.success) {
        this.userManagerService.toggleLike(memberId);
        //this.toastr.success("Userlike toggled");
      } else {
        //this.toastr.error("Something bad happened.");
      }
    })*/
  }
}
