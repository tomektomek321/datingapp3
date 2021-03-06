import { Photo } from './photo';

export interface UserHobbies {
    id: number;
    name: string;
}

export interface City {
    id: number;
    name: string;
}

export interface Member {
    id: number;
    username: string;
    photoUrl: string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive: Date;
    gender: string;
    introduction: string;
    lookingFor: string;
    interests: string;
    city: string;
    country: string;
    photos: Photo[];
    userHobbies: UserHobbies[];
}