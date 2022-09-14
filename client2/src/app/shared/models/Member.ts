import { IdName } from "./IdName";
import { likedUsers } from "./LikedUsers";
import { Photo } from "./Photo";

export interface Member {
    id: number;
    username: string;
    photoUrl?: string;
    age?: number;
    knownAs: string;
    created: Date;
    lastActive?: Date;
    gender?: string;
    introduction?: string;
    lookingFor?: string;
    interests?: string;
    city?: string;
    country?: string;
    photos?: Photo[];
    hobbies: IdName[];
    likedUsers: likedUsers[],

}
