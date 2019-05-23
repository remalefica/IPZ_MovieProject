import { Component, OnInit,ViewChild } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Router } from '@angular/router';
import { MustMatch} from '../../directives/must-match.validator';
import { UserRegistrationModel } from '../../models/user-registration-model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit{
  user: UserRegistrationModel = {
    login: '',
    email: '',
    password: '',
    confirmPassword: ''
  };
 @ViewChild('userForm') form: any;

 constructor() { }
 ngOnInit() { }

 onSubmit({value,valid}: {value: UserRegistrationModel, valid: boolean}) {
   if(!valid){
     console.log('Form is not valid');
   } else {
     console.log('Form was submitted');
     this.form.reset();
   }
 }
  //constructor(private authService: AuthService, private router: Router) { }
 
  //   this.authService.singUp(<UserLoginModel> { 
  //     login: this.registerForm.controls.firstName, 
  //     password: this.registerForm.controls.password},
  //     this.registerForm.controls.email
  //       )
  // .subscribe(_ => {
  //   this.router.navigate(['films']);
  // });
}