import { Component, OnInit } from '@angular/core';
import { Film } from '../film';


@Component({
  selector: 'app-films',
  templateUrl: './films.component.html',
  styleUrls: ['./films.component.css']
})
export class FilmsComponent implements OnInit {

  films: Film[] =[
    {id: 1, name: 'The Shawshank Redemption',director: 'Frank Darabont', year: 1994, 
    description: 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.',
    filmImgPath: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0yTXtgWAvtoc_UXri2QUFkzXNfRWIqZrf9YvprKdutn808ZHO', 
    filmTrailerPath:'https://www.youtube.com/embed/BXUEUwwgIyU',
    originCountry:'USA', budget: 25000000, ratingAvg: 9.3, 
    comments:[],
    votes:[],
    genre:[8],
    durationInMinutes: 142
    },
    {id: 2, name: 'Forrest Gump', year: 2001, description: 'Good film'},
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
