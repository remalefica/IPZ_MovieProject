import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { FilmsComponent } from './components/films/films.component';
import { FilmComponent } from './components/film/film.component';
import { RatingVotingComponent } from './components/rating-voting/rating-voting.component';
import { AppRoutingModule } from './/app-routing.module';
import { MessagesComponent } from './components/messages/messages.component';
import { CommentService } from './services/comment/comment.service';
import { CommentComponent } from './components/comment/comment.component';
import { CommentsListComponent } from './components/comments-list/comments-list.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AuthorisationComponent } from './components/authorisation/authorisation.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { NavBarFooterComponent } from './components/nav-bar-footer/nav-bar-footer.component';

import { TopfilmsComponent } from './components/topfilms/topfilms.component';
import { AccountComponent } from './components/account/account.component';
import { AllcommentsComponent } from './components/allcomments/allcomments.component';
import { AllvotesComponent } from './components/allvotes/allvotes.component';
import { AuthService } from './services/authorisation/authorisation.service';
import { JwtService } from './services/authorisation/jwt.service';
import { ErrorHandlingService } from './services/authorisation/error-handling.service';
import {TokenInterceptor} from './interceptor/token.interceptor';

import { ForbiddenValidatorDirective } from './directives/forbidden-name.directive';
import { IdentityRevealedValidatorDirective } from './directives/identity-revealed.directive';

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
    NavBarFooterComponent,
    TopfilmsComponent,
    AccountComponent,
    AllcommentsComponent,
    AllvotesComponent,

    ForbiddenValidatorDirective,
    IdentityRevealedValidatorDirective
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
    ]),
    AppRoutingModule
  ],
  providers: [AuthService,  JwtService,
    { provide: Window, useValue: window },
    {
       provide: HTTP_INTERCEPTORS,
       useClass: TokenInterceptor,
       multi: true
    }, ErrorHandlingService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
