import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchUserReqDto } from 'src/app/pages/searchFilters/models/SearchUserDto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FilteredMembersGatewayService {

  constructor(
    private http: HttpClient,
  ) { }

  public fetchFilteredMembers(filterParams: SearchUserReqDto) {
    return this.http.post<SearchUserReqDto>(
      environment.apiUrl + 'Member/FilterMembers',
      filterParams
    )
  }


}
