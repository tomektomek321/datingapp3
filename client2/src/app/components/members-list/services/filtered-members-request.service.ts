import { Injectable } from '@angular/core';
import { IdName } from 'src/app/shared/models/IdName';
import { Member } from 'src/app/shared/models/Member';
import { SearchUserReqDto } from 'src/app/shared/models/searchUsers/Dtos/SearchUserDto';
import { SearchUserParams } from 'src/app/shared/models/searchUsers/SearchUserParams';
import { SearchBarService } from '../../search-bar/services/search-bar.service';
import { FilteredMembersGatewayService } from 'src/app/domains/filtered-members/filtered-members-gateway.service';
import { FilteredMembersService } from '../../likes-list/services/filtered-members.service';

@Injectable({
  providedIn: 'root'
})
export class FilteredMembersRequestService {

  constructor(
    private searchBarService: SearchBarService,
    private memberListService: FilteredMembersService,
    private filteredMembersGatewayService: FilteredMembersGatewayService,
  ) { }

  createFilterParams(): SearchUserReqDto {
    const params: SearchUserParams = this.searchBarService.getSearchUserParams();

    const citiesString = this.createCitiesIdStringForRequest(params.cities);
    const hobbiesString = this.createCitiesIdStringForRequest(params.hobbies);

    return {
      gender: typeof(params.gender) == 'number' ? params.gender : parseInt(params.gender) as 1 | 0,
      maxAge: params.maxAge,
      minAge: params.minAge,
      orderBy: params.orderBy,
      cities: citiesString,
      hobbies: hobbiesString,
    }
  }

  loadMembers(): void {
    const filterParams = this.createFilterParams();

    this.filteredMembersGatewayService.fetchFilteredMembers(filterParams)
    .subscribe((response: any) => {
      const members: Member[] = response.data;
      this.memberListService.setFilteredMembers(members);
    });
  }

  createCitiesIdStringForRequest(cities: IdName[]) {
    let citiesString = "";

    cities.forEach(element => {
      citiesString += (element.id + "-");
    });

    citiesString = citiesString.slice(0, citiesString.length - 1);

    return citiesString;
  }
}
