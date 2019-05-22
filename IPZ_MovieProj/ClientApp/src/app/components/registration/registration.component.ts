import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Router } from '@angular/router';
import { newUser } from '../../models/newUser';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { identityRevealedValidator } from '../../directives/identity-revealed.directive';
import { forbiddenNameValidator } from '../../directives/forbidden-name.directive';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit{

  newUser = { login: '', email: '', password: '', passwordConfirm: ''};
  userForm: FormGroup;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  //constructor(private alterEgoValidator: UniqueAlterEgoValidator) { }

  this.userForm = new FormGroup({
    'login': new FormControl(this.newUser.login, [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(20),
      forbiddenNameValidator(/admin/i)
    ]),
    'email': new FormControl(this.newUser.email, [
      Validators.required,
      Validators.maxLength(40)
    ]),
    'password': new FormControl(this.newUser.password, [
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(20)
    ]),
    'passwordConfirm': new FormControl(this.newUser.passwordConfirm, [
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(20)
    ]),
  },  { validators: identityRevealedValidator }); // <-- add custom validator at the FormGroup level
  };

  get login() { return this.userForm.get('login'); }

  get email() { return this.userForm.get('email'); }

  get password() { return this.userForm.get('password'); }

  get passwordConfirm() { return this.userForm.get('passwordConfirm'); }

  public signUp(): void {
    
    
    if (this.password !== this.passwordConfirm) {
      alert('passwords are differrent!');
      return;
    }

    this.authService.singUp(<newUser> { 
      login: this.newUser.login, 
      password: this.newUser.password},
      this.newUser.email
        )
    .subscribe(_ => {
    this.router.navigate(['films']);
  });  

  


    

    

    // this.authService.validateLogin(this.login).pipe(
    //   tap(isValid => {
    //     if (!isValid) {
    //       alert('user with such login already exists');
    //     }
    //   }),
    //   filter(isValid => isValid),
    //   mergeMap(_ =>
    //     this.authService.singUp(<UserLoginModel> { login: this.login, password: this.password },
    //       this.firstName, this.lastName))
    // ).subscribe(_ => {
    //   this.router.navigate(['dashboards'])
    // });
  }

}
