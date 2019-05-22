import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private authService: AuthService,
               private router: Router) { }

  ngOnInit() {
  }

  public get isUserSignedIn$(): Observable<boolean> {
    return this.authService.isSignedIn();
  }

  public signOut(): void {
    this.authService.signOut().subscribe(() => {
      this.router.navigate([''])
    })
  }

}
