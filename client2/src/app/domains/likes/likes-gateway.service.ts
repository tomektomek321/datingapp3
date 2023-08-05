import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/shared/models/Member';
import { environment } from 'src/environments/environment';

interface ILikeMemberPayload {
  sourceUserId: number;
  targetUserId: number;
  isLiked: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class LikesGatewayService {
  constructor(private readonly http: HttpClient) { }

  public likeMember(payload: ILikeMemberPayload): Observable<Member[]> {
    return this.http.post<Member[]>(`${environment.apiUrl}Like/LikeUser`, payload);
  }
}
