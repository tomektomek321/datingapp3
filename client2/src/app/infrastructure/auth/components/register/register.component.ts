import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { RegisterService } from 'src/app/infrastructure/auth/services/register/register.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

    registerForm!: FormGroup;
    maxDate!: Date;
    validationErrors: string[] = [];

    constructor(
        private fb: FormBuilder,
        private registerService: RegisterService,
    ) { }

    ngOnInit(): void {
        this.registerForm = this.fb.group({
            gender: ['1'],
            username: ['tom12345', Validators.required],
            knownAs: ['tom12345', Validators.required],
            dateOfBirth: ['', Validators.required],
            city: ['', Validators.required],
            country: ['', Validators.required],
            password: ['tomee', [Validators.required, Validators.maxLength(8), Validators.minLength(4)]],
            confirmPassword: ['tomee', [Validators.required, this.matchValues('password')]]
        })
    }

    matchValues(matchTo: string): ValidatorFn {
        return (control: AbstractControl) => {
            if(control?.parent?.controls!= null) {
                const x = control?.parent?.controls as { [key: string]: AbstractControl };
                return x[matchTo].value == control?.value ? null : { isMatching: true };
            }

            return { isMatching: true };
        }
    }

    selectCity($event: any): void {
        this.registerForm.controls['city'].setValue($event.id);
    }

    selectCountry($event: any): void {
        this.registerForm.controls['country'].setValue($event.id);
    }

    register(): void {
        this.registerService.register(this.registerForm.value).subscribe(response => {
            console.log(123);debugger
        }, error => {
            this.validationErrors = error;
        })
    }

}
