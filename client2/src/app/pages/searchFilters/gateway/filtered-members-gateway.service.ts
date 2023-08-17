import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchUserReqDto } from 'src/app/pages/searchFilters/models/SearchUserDto';
import { environment } from 'src/environments/environment';
import { MyFilterSettingsRs } from '../models/myFilterSettings/MyFilterSettings';

@Injectable({
  providedIn: 'root',
})
export class FilteredMembersGatewayService {
  constructor(
    private http: HttpClient,
  ) { }

  public fetchFilteredMembers(filterParams: SearchUserReqDto) {
    return this.http.post<SearchUserReqDto>(
      environment.apiUrl + 'Member/FilterMembers',
      filterParams,
    );
  }

  public getMyFilterSettings() {
    return this.http.post<MyFilterSettingsRs>(
      environment.apiUrl + 'MySettingsAndFilters/GetMyFilterSettings',
      {},
    );
  }

  public toggleHobby(hobbyId: number) {
    return this.http.get<MyFilterSettingsRs>(
      environment.apiUrl + 'MySettingsAndFilters/ToggleHobby/' + hobbyId,
    );
  }
}
