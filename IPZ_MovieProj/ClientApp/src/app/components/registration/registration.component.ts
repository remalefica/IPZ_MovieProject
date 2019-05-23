import { Component, OnInit,ViewChild } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Router } from '@angular/router';
import { MustMatch} from '../../directives/must-match.validator';
import { UserRegistrationModel } from '../../models/user-registration-model';
import { UserLoginModel } from '../../models/user-login-model';
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

 constructor (
   private formBuilder: FormBuilder, 
   private authService: AuthService, 
   private router: Router
   )
   { }

 ngOnInit() {
  this.registerForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(20), Validators.pattern]],
      email: ['', [Validators.required, Validators.pattern]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(20)]],
      confirmPassword: ['', Validators.required]
  }, {
      validator: MustMatch('password', 'confirmPassword')
  });
}

// convenience getter for easy access to form fields
get f() { return this.registerForm.controls; }

 public onSubmit() {
     //this.form.reset();
     this.authService.singUp(<UserLoginModel> { 
      login: this.user.login, 
      password: this.user.password},
      this.user.email)
      .subscribe(_ => {
        this.router.navigate(['films']);})
   }


//  public signUp(): void {


//   this.authService.singUp(<UserLoginModel> { 
//       login: this.login, 
//       password: this.password},
//       this.email
//         )
//   .subscribe(_ => {
//     this.router.navigate(['films']);
//   });



  //   this.authService.singUp(<UserLoginModel> { 
  //     login: this.registerForm.controls.firstName, 
  //     password: this.registerForm.controls.password},
  //     this.registerForm.controls.email
  //       )
  // .subscribe(_ => {
  //   this.router.navigate(['films']);
  // });
}