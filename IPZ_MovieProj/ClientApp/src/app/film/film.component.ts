import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import {Film} from '../models/film'
import { FilmService } from '../services/film/film.service';
import {Genre, GenreFilm} from '../models/genre'; 

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

  goBack(): void {
    this.location.back();
  }

}
