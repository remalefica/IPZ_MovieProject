import { Injectable, ErrorHandler, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, of, throwError, BehaviorSubject } from 'rxjs';
import { delay, catchError, tap, map } from 'rxjs/operators';
import { ErrorHandlingService } from './error-handling.service';
import { User, UserLoginModel } from '../../models';
import { HttpClient } from '@angular/common/http';
import { JwtService } from './jwt.service';
import { MessageService } from '../message/message.service';

@Injectable()
export class AuthService {

  private currentUser$ = new BehaviorSubject<User>(null);
  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private jwtService: JwtService,
    private errorHandlingService: ErrorHandlingService) { 
      this.url = 'https://localhost:5001' + '/api/Authorisation/';
    }

  public isSignedIn(): Observable<boolean> {
    return this.currentUser$.pipe(
      map(currentUser => !!currentUser)
    );
  }

  public signIn(loginModel: UserLoginModel): Observable<User> {
    let PATH = this.url +'SignIn';

    return this.httpClient.post<any>(PATH, loginModel).pipe(
      tap(({user, token}) => {
        this.jwtService.persistToken(token);
        this.currentUser$.next(user as User);

        this.messageService.add('AuthorisationService: user signed in');
      }),
      catchError(this.errorHandlingService.handleError)
    );
  }

  public singUp(loginModel: UserLoginModel, email: string): Observable<User> {
    const PATH = this.url + 'SignUp';

    return this.httpClient.post<any>(PATH, {
      signInModel: loginModel,
      email: email
    }).pipe(
      tap(({user, token}) => {
        this.jwtService.persistToken(token);
        this.currentUser$.next(user as User);

        this.messageService.add('AuthorisationService: user signed up');
      }),
      catchError(this.errorHandlingService.handleError)
    );
  }

  public signOut(): Observable<void> {
    return of(null).pipe(
      delay(1500),
      tap(() => {
        this.currentUser$.next(null);
        this.jwtService.clearToken();
      })
    )
  }

  public getCurrentUser(): Observable<User> {
    return this.currentUser$.asObservable();
  }
}