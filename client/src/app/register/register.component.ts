import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterHintsService } from './register-hints.service';

interface IdName {
    id: number;
    name: string;
}

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
    @Output() cancelRegister = new EventEmitter()
    registerForm: FormGroup;
    maxDate: Date;
    validationErrors: string[] = [];


    cityToAdd: string
    cityToAddObject: IdName

    allCitiesNames: any = []
    citiesNamesPromptsShow = false
    citiesNamesPrompts: any = []


    countryToAdd: string
    countryToAddObject: IdName

    allCountriesNames: any = []
    countriesNamesPromptsShow = false
    countriesNamesPrompts: any = []




    constructor(
        private registerHints: RegisterHintsService,
        private accountService: AccountService,
        private toastr: ToastrService,
        private fb: FormBuilder,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.registerForm = this.fb.group({
            gender: ['male'],
            username: ['', Validators.required],
            knownAs: ['', Validators.required],
            dateOfBirth: ['', Validators.required],
            city: ['', Validators.required],
            country: ['', Validators.required],
            password: ['', [Validators.required,
            Validators.minLength(4), Validators.maxLength(8)]],
            confirmPassword: ['', [Validators.required, this.matchValues('password')]]
        })
    }

    matchValues(matchTo: string): ValidatorFn {
        return (control: AbstractControl) => {
            return control?.value === control?.parent?.controls[matchTo].value
                ? null : { isMatching: true }
        }
    }

    showCountriesHints() {
        this.registerHints.showCountriesHints(this.registerForm.controls.country.value).subscribe(response => {
            console.log(response)
            this.allCountriesNames = response
            this.showCountriesPrompt()
        })
    }

    showCountriesPrompt() {
        this.countriesNamesPromptsShow = true;
    }

    selectCountry(country_) {
        this.countriesNamesPromptsShow = false
        this.countryToAdd = country_.name
        this.countryToAddObject = country_;
        this.registerForm.controls.country.setValue(country_.name)
        console.log(this)
    }


    showCitiesHints() {
        this.registerHints.showCitiesHints(this.registerForm.controls.city.value).subscribe(response => {
            console.log(response)
            this.allCitiesNames = response
            this.showCitiesPrompt()
        })
    }

    showCitiesPrompt() {
        this.citiesNamesPromptsShow = true;
    }

    selectCity(city_) {
        this.citiesNamesPromptsShow = false
        this.cityToAdd = city_.name
        this.cityToAddObject = city_
        this.registerForm.controls.city.setValue(city_.name)
    }


    register() {

        this.registerForm.controls.country.setValue(this.countryToAddObject.id)
        this.registerForm.controls.city.setValue(this.cityToAddObject.id)

        this.accountService.register(this.registerForm.value).subscribe(response => {
            this.router.navigateByUrl('/members');
        }, error => {
            this.validationErrors = error;
            this.registerForm.controls.country.setValue(this.countryToAddObject.name)
            this.registerForm.controls.city.setValue(this.cityToAddObject.name)
        })
    }

    cancel() {
        this.cancelRegister.emit(false)
    }

}
