import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

interface ILikeMemberPayload {
  sourceUserId: number;
  targetUserId: number;
  isLiked: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class LikesGatewayService {

  constructor(private readonly http: HttpClient) { }

  public likeMember(payload: ILikeMemberPayload) {
    return this.http.post(`${environment.apiUrl}Like/LikeUser`, payload);
  }
}
