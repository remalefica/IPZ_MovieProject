import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Router } from '@angular/router';
import { UserLoginModel } from '../../models';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent {

  public login: string;
  public password: string;
  public password2: string;
  public email: string;

  constructor(private authService: AuthService, private router: Router) { }

  public signUp(): void {
    if (this.password !== this.password2) {
      alert('passwords are differrent!');
      return;
    }

    this.authService.singUp(<UserLoginModel> { 
        login: this.login, 
        password: this.password},
        this.email
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
