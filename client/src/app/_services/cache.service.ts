import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CacheService {

    memberCache = new Map();

    constructor() { }

    getMember(username: string) {
        const member = [...this.memberCache.values()]
            .reduce((arr, elem) => arr.concat(elem.result), [])
            .find((member) => member.username === username);

        if (member) {
            //return of(member);
        }

    }






}
