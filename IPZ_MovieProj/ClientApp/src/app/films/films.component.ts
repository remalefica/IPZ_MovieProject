import { Component, OnInit } from '@angular/core';
import { Film } from '../film';


@Component({
  selector: 'app-films',
  templateUrl: './films.component.html',
  styleUrls: ['./films.component.css']
})
export class FilmsComponent implements OnInit {

  films: Film[] =[
    {id: 1, name: 'Film1', year: 2000, description: 'Nice film'},
    {id: 2, name: 'Film2', year: 2001, description: 'Good film'},
    {id: 3, name: 'Film3', year: 2002, description: 'Great film'},
    {id: 4, name: 'Film4', year: 2003, description: 'Wonderful film'}
  ];

  selectedFilm: Film;

  onSelect(film: Film): void {
  this.selectedFilm = film;
}

  constructor() { }

  ngOnInit() {
  }

}
