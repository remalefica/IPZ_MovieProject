import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Router, ActivatedRoute } from '@angular/router';
import { JwtService } from '../../services/authorisation/jwt.service';
import { MessageService } from '../../services/message/message.service';

@Component({
  selector: 'app-authorisation',
  templateUrl: './authorisation.component.html',
  styleUrls: ['./authorisation.component.css'],
})
export class AuthorisationComponent {
  username: string;
  password: string;

  constructor(private messageService: MessageService,private router: Router, private authService: AuthService) { }

  login(): void {
    this.authService.signIn({
      login: this.username,
      password: this.password
    }).subscribe(() => {
     this.router.navigate(['films']);
    }, () => {
      this.messageService.add('Authorization error.');
    });
  }
}

