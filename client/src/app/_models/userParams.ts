import { User } from './user'

export class UserParams {
    gender: string
    minAge = 18
    maxAge = 99
    pageNumber = 1
    pageSize = 45
    orderBy = 'lastActive'
    cities = []

    constructor(user: User) {
        this.gender = user.gender === 'female' ? 'male' : 'female'
    }
}