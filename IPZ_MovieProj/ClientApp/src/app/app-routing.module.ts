import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmComponent } from './film/film.component';
import { RatingVotingComponent} from './rating-voting/rating-voting.component'
import { FilmsComponent } from './films/films.component';
import { Film } from './models/film';
import { AuthorisationComponent } from './authorisation/authorisation.component';
import { RegistrationComponent } from './registration/registration.component';
import { TopfilmsComponent } from './topfilms/topfilms.component'
import { AccountComponent } from './account/account.component';
import { AllcommentsComponent } from './allcomments/allcomments.component';
import { AllvotesComponent } from './allvotes/allvotes.component';

const routes: Routes = [
  {path:'', redirectTo: '/films', pathMatch: 'full'},
  {path: 'sign-in', component: AuthorisationComponent},
  {path: 'sign-up', component: RegistrationComponent},
  {path: 'topmovies', component: TopfilmsComponent},
  {path: 'account', component: AccountComponent},
  {path: 'allcomments', component: AllcommentsComponent},
  {path: 'allvotes', component: AllvotesComponent},
  {path: 'films', component:  FilmsComponent},
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
