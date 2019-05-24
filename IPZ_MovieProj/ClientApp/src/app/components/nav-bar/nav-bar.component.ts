import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Film } from '../../models/film';
import { FilmService } from '../../services/film/film.service';
import {FilmSearchPipe} from './filmname.pipe';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  url : string;
  searchText : string;
  films: Film[];

  constructor(@Inject(DOCUMENT) private document: any,
              private authService: AuthService,
               private router: Router,
               private filmService: FilmService) { }

  ngOnInit() {
    this.getFilms();
    this.url = "https://localhost:5001/films/";
  }
  getFilms(): void {
    this.filmService.getFilms()
    .subscribe(films => this.films = films);
  }

  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }

  public signOut(): void {
    this.authService.signOut().subscribe(() => {
      this.router.navigate([''])
    })
  }

  goToUrl(filmId : number): void {
    this.document.location.href = this.url + `${filmId}`;
}

}
