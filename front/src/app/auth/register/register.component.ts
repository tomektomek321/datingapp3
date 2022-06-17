import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

    registerForm: FormGroup;
    maxDate?: Date;
    validationErrors: string[] = [];

    constructor(
        private _formBuilder: FormBuilder,
    ) {
        this.maxDate = new Date();
        this.maxDate.setFullYear(this.maxDate.getFullYear() -18);

        this.registerForm = this._formBuilder.group({
            gender: ['male'],
            username: ['', Validators.required],
            // knownAs: ['', Validators.required],
            // dateOfBirth: ['', Validators.required],
            // city: ['', Validators.required],
            // country: ['', Validators.required],
            // password: ['', [Validators.required,
            //   Validators.minLength(4), Validators.maxLength(8)]],
            // confirmPassword: ['', [Validators.required, this.matchValues('password')]]
          })
    }

    ngOnInit(): void {

    }

    /*matchValues(matchTo: string): ValidatorFn {
        return (control: AbstractControl) => {
          return control?.value === control?.parent?.controls[matchTo].value
            ? null : {isMatching: true}
        }
      }*/

      private matchValues(matchTo: string): ValidatorFn {
        return (control: AbstractControl) => {
          if (control.parent && control.parent.controls) {
            return control.value === (control.parent.controls as { [key: string]: AbstractControl })[matchTo].value
              ? null : { isMatching: true };
          }
          return null;
        }
      }

    register() {
    }

}
