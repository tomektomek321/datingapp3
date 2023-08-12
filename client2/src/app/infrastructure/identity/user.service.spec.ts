import { TestBed } from '@angular/core/testing';
import { User } from 'src/app/shared/models/identity/AppUser';
import { UserService } from './user.service';

describe('UserService', () => {
    let service: UserService;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(UserService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });


    // it('Init user should have id = 0', () => {
    //     const startUser = service.getUser();
    //     expect(startUser.id).toBe(0);

    // });

    // it('Set user with id = 1, then user should have id = 1', () => {
    //     const testUser: User = {
    //         id: 1,
    //         age: 20,
    //         userName: "Tomek",
    //         knownAs: "Tom",
    //         city: "Gorzow",
    //         country: "Poland",
    //         gender: "Male",
    //         hobbies: [],
    //     }

    //     service.setUser(testUser);

    //     const startUser = service.getUser();

    //     expect(startUser.id).toBe(1);

    // });


    // it('Set user with id = 0, then user should have id = 0', () => {
    //     const testUser: User = {
    //         id: 0
    //     }

    //     service.setUser(testUser);

    //     const startUser = service.getUser();

    //     expect(startUser.id).toBe(0);

    // });

});
