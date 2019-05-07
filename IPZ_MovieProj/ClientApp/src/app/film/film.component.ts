import { Component, OnInit } from '@angular/core';
import {Film} from '../film'

@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.css']
})
export class FilmComponent implements OnInit {

// need film: Film;
// code below is made of shit and sticks :)
  film: Film = {
    id: 1,
    name: "FilmName",
    description: "BlaBla"
  };

  constructor() { }

  ngOnInit() {
  }

}
