import { likedUsers } from "../LikedUsers";

export interface User {
    id: number;
    username?: string;
    knownAs?: string;
    token?: string;
    likedUsers?: likedUsers;
}