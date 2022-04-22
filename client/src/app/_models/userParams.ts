import { User } from './user'

export class UserParams {
    gender: string
    minAge = 18
    maxAge = 25
    pageNumber = 1
    pageSize = 25
    orderBy = 'lastActive'
    cities = []

    constructor(user: User) {
        this.gender = user.gender === 'female' ? 'male' : 'female'
    }
}