import { IdName } from "../IdName";
import { likedUsers } from "../LikedUsers";

export interface User {
  id: number;
  username?: string;
  knownAs?: string;
  token?: string;
  photoUrl?: string;
  gender?: string;
  likedUsers?: likedUsers[];
  hobbies?: IdName[],
  city?: string;
  country?: string;
  age?: number;
}