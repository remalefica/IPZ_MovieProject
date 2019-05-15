import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import {Film} from '../models/film'
import { FilmService } from '../services/film/film.service';
import {Genre} from '../models/genre';


@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.css']
})
export class FilmComponent implements OnInit {
  
  film: Film;

  constructor(
    private route: ActivatedRoute,
    private filmService: FilmService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getFilm();
  }

  getFilm(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.filmService.getFilm(id)
      .subscribe(film => this.film = film);
  }

  getFilmGenre(genre: Genre) : string {
      switch (genre) {
        case Genre.Action:
          return 'Action';
        case Genre.Adventure:
          return 'Adventure';
        case Genre.Biography:
          return 'Biography';
        case Genre.Comedy:
          return 'Comedy';
        case Genre.Crime:
          return 'Crime';
        case Genre.Documentary:
          return 'Documentary';
        case Genre.Drama:
          return 'Drama';
        case Genre.Family:
          return 'Family';
        case Genre.Fantasy:
          return 'Fantasy';
        case Genre.History:
          return 'History';
        case Genre.Horror:
          return 'Horror';
        case Genre.Music:
          return 'Music';
        case Genre.Musical:
          return 'Musical';
        case Genre.Mystery:
          return 'Mystery';
        case Genre.Romance:
          return 'Romance';
        case Genre.SciFi:
          return 'SciFi';
        case Genre.Short:
          return 'Short';
        case Genre.Sport:
          return 'Sport';
        case Genre.Superhero:
          return 'Superhero';
        case Genre.Thriller:
          return 'Thriller';
        case Genre.War:
          return 'War';
        case Genre.Western:
          return 'Western';
        default:
          break;
      }
  }

  goBack(): void {
    this.location.back();
  }
}
