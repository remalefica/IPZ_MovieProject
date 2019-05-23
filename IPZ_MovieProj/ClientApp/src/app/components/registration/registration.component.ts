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

  registerForm: FormGroup;

  user: UserRegistrationModel = {
    login: '',
    email: '',
    password: '',
    confirmPassword: ''
  };
 @ViewChild('userForm') form: any;

 constructor(private formBuilder: FormBuilder) { }

 ngOnInit() {
  this.registerForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]],
      email: ['', [Validators.required, Validators.pattern]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(20)]],
      confirmPassword: ['', Validators.required]
  }, {
      validator: MustMatch('password', 'confirmPassword')
  });
}

// convenience getter for easy access to form fields
get f() { return this.registerForm.controls; }

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