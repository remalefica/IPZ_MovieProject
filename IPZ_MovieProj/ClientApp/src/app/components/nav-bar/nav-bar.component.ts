import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Film } from '../../models/film';
import { FilmService } from '../../services/film/film.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  searchText;
  films: Film[];

  constructor(private authService: AuthService,
               private router: Router,
               private filmService: FilmService) { }

  ngOnInit() {
    this.getFilms();
  }
  getFilms(): void {
    this.filmService.getFilms()
    .subscribe(films => this.films = films);
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
