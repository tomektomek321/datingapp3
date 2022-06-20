import { likedUsers } from "../LikedUsers";

export interface User {
    id: number;
    userName?: string;
    knownAs?: string;
    token?: string;
    photoUrl?: string;
    gender?: string;
    likedUsers?: likedUsers;
}