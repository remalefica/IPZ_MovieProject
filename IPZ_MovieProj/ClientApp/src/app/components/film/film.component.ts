import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import {Film} from '../../models/film'
import { FilmService } from '../../services/film/film.service';
import {Genre, GenreFilm} from '../../models/genre'; 
import { GenreService } from 'src/app/services/genre.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.css']
})
export class FilmComponent implements OnInit {
  
  trustedVideoURL : any;
  film: Film;
  genres = [];

  constructor(
    private route: ActivatedRoute,
    private filmService: FilmService,
    private genreService: GenreService,
    private location: Location,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.getInfo();
  }

  getInfo(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    this.filmService.getFilm(id)
      .subscribe(film => {
        this.film = film;
        this.trustedVideoURL = this.sanitizer.bypassSecurityTrustResourceUrl(this.film.filmTrailerPath);
      });

    this.genreService.getGenre(id)
    .subscribe(genres => {
      this.film.genres = genres;
      genres.forEach(genre => {
        this.genres.push(Genre[genre.genreName]);
      });
    });
  }

  goBack(): void {
    this.location.back();
  }

}
