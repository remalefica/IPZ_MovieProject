import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { User } from '../../models';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/services/user/user.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  user : User;

  constructor(private router: Router, 
              private authService: AuthService) { }

  ngOnInit() {
    this.getUser();
  }

  getUser() : void{
    this.authService.getCurrentUser()
      .subscribe(userAut => this.user = userAut);
  }
}
