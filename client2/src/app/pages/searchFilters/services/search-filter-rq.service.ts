import { Injectable } from '@angular/core';
import { SearchFiltersService } from './search-filters.service';
import { FilteredMembersGatewayService } from '../gateway/filtered-members-gateway.service';
import { FilteredMembersService } from 'src/app/components/likes-list/services/filtered-members.service';
import { createFilterParams } from '../utils/createParamsForRequest';
import { Member } from 'src/app/shared/models/Member';
import { SearchFiltersManagerService } from './search-filters-manager.service';

@Injectable({
  providedIn: 'root',
})
export class SearchFilterRqService {
  constructor(
    private searchFiltersService: SearchFiltersService,
    private searchFiltersManagerService: SearchFiltersManagerService,
    private memberListService: FilteredMembersService,
    private filteredMembersGatewayService: FilteredMembersGatewayService,
  ) { }

  getMyFilterSettings() {
    return this.filteredMembersGatewayService.getMyFilterSettings();
  }

  loadMembers(): void {
    const params = this.searchFiltersService.getSearchUserParams();
    const filterParams = createFilterParams(params);

    this.filteredMembersGatewayService.fetchFilteredMembers(filterParams)
      .subscribe((response: any) => {
        console.log(response);
        const members: Member[] = response.data;
        this.memberListService.setFilteredMembers(members);
      });
  }

  toggleHobby(hobbyId: number): void {
    this.filteredMembersGatewayService.toggleHobby(hobbyId)
      .subscribe((response: any) => {
        if(!response.success) {
          console.log('SearchFilterRqService.toggleHobby error');
        }

        this.searchFiltersManagerService.toggleHobby({
          id: hobbyId,
          name: '',
        });
      });
  }
}
