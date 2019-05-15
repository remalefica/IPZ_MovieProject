import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FilmsComponent } from './films/films.component';
import { FilmComponent } from './film/film.component';
import { RatingVotingComponent } from './rating-voting/rating-voting.component';
import { AppRoutingModule } from './/app-routing.module';
import { MessagesComponent } from './messages/messages.component';
import { CommentService } from './services/comment/comment.service';
import { CommentComponent } from './comment/comment.component';
import { CommentsListComponent } from './comments-list/comments-list.component';
import { RegistrationComponent } from './registration/registration.component';
import { AuthorisationComponent } from './authorisation/authorisation.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NavBarFooterComponent } from './nav-bar-footer/nav-bar-footer.component';

@NgModule({
  declarations: [
    AppComponent,
    FilmsComponent,
    FilmComponent,
    RatingVotingComponent,
    MessagesComponent,
    CommentComponent,
    CommentsListComponent,
    RegistrationComponent,
    AuthorisationComponent,
    NavBarComponent,
    NavBarFooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
    ]),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
