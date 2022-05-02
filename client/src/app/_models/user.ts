
export interface User {
    id: number;
    username: string;
    token: string;
    photoUrl: string;
    knownAs: string;
    gender: string;
    likedUsers: LikedUsers[],
    hobbies: {id: number, name: string}[],
    city: string;
    country: string;
    age: number;
    lastActive: Date,
}

export interface LikedUsers {
    sourceId: number;
    targetId: number;
}