import { IdName } from "../IdName";

export interface SearchUserParams {
    gender: 1 | 0;
    minAge: number;
    maxAge: number;
    orderBy: string;
    cities: IdName[];
    hobbies: IdName[];
}
