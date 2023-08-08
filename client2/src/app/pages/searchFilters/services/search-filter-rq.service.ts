import { Injectable } from '@angular/core';
import { SearchFilterService } from './search-filter.service';
import { FilteredMembersGatewayService } from '../gateway/filtered-members-gateway.service';
import { FilteredMembersService } from 'src/app/components/likes-list/services/filtered-members.service';
import { createFilterParams } from '../utils/createParamsForRequest';
import { Member } from 'src/app/shared/models/Member';

@Injectable({
  providedIn: 'root',
})
export class SearchFilterRqService {
  constructor(
    private searchBarService: SearchFilterService,
    private memberListService: FilteredMembersService,
    private filteredMembersGatewayService: FilteredMembersGatewayService,
  ) { }

  loadMembers(): void {
    const params = this.searchBarService.getSearchUserParams();
    const filterParams = createFilterParams(params);

    this.filteredMembersGatewayService.fetchFilteredMembers(filterParams)
      .subscribe((response: any) => {
        console.log(response);
        const members: Member[] = response.data;
        this.memberListService.setFilteredMembers(members);
      });
  }
}
