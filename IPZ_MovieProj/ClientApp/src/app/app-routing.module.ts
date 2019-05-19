import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmComponent } from './components/film/film.component';
import { RatingVotingComponent} from './components/rating-voting/rating-voting.component'
import { FilmsComponent } from './components/films/films.component';
import { Film } from './models/film';
import { AuthorisationComponent } from './components/authorisation/authorisation.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { TopfilmsComponent } from './components/topfilms/topfilms.component'
import { AccountComponent } from './components/account/account.component';
import { AllcommentsComponent } from './components/allcomments/allcomments.component';
import { AllvotesComponent } from './components/allvotes/allvotes.component';

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
