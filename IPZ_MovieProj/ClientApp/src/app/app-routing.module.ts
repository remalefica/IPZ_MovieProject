import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmComponent } from './film/film.component';
import { RatingVotingComponent} from './rating-voting/rating-voting.component'
import { FilmsComponent } from './films/films.component';

const routes: Routes = [
  {path: 'films', component: FilmsComponent}
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
