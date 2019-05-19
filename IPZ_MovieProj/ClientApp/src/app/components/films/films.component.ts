import { Component, OnInit } from '@angular/core';
import { Film } from '../../models/film';
import { FilmService } from '../../services/film/film.service';
import { Genre } from '../../models/genre';


@Component({
  selector: 'app-films',
  templateUrl: './films.component.html',
  styleUrls: ['./films.component.css']
})
export class FilmsComponent implements OnInit {
  films: Film[];
  genres: string[];

  constructor(private filmService: FilmService) { }

  ngOnInit() {
    this.genres = Object.keys(Genre).filter(k => typeof Genre[k as any] === "number");
    this.getFilms();
  }

  getFilms(): void {
    this.filmService.getFilms()
    .subscribe(films => this.films = films);
  }
}
