import { Component, OnInit } from '@angular/core';
import { Film } from '../../models/film';
import { FilmService } from '../../services/film/film.service';
import { Genre } from '../../models/genre';
@Component({
  selector: 'app-topfilms',
  templateUrl: './topfilms.component.html',
  styleUrls: ['./topfilms.component.css']
})
export class TopfilmsComponent implements OnInit {

  films: Film[];

  constructor(private filmService: FilmService) { }

  ngOnInit() {
    this.getTop();
  }

  getTop(): void {
    this.filmService.getTop()
    .subscribe(films => this.films = films);
  }

}
