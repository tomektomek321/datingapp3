import { User } from './user'

export class UserParams {
    gender: string
    minAge = 18
    maxAge = 45
    pageNumber = 1
    pageSize = 25
    orderBy = 'lastActive'
    cities = []

    constructor(user: User) {
        this.gender = String(user.gender) === '0' ? '1' : '0'
    }
}