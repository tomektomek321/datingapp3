
export interface SearchUserDto {
    gender: 1 | 0;
    minAge: number;
    maxAge: number;
    orderBy: string;
    cities: string;
    hobbies: string;
}