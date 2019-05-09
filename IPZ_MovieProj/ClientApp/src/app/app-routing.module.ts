import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmComponent } from './film/film.component';
import { RatingVotingComponent} from './rating-voting/rating-voting.component'
import { FilmsComponent } from './films/films.component';
import { Film } from './film';

const routes: Routes = [
  {path:'', redirectTo: '/films', pathMatch: 'full'},
  {path: 'films', component: FilmsComponent},
  {path: ':id', component: FilmComponent}
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
