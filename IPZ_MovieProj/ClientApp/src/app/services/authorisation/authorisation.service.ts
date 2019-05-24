import { Injectable, ErrorHandler, Inject } from '@angular/core';
import { Router, ActivatedRoute, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of, throwError, BehaviorSubject } from 'rxjs';
import { delay, catchError, tap, map } from 'rxjs/operators';
import { ErrorHandlingService } from './error-handling.service';
import { User, UserLoginModel } from '../../models';
import { HttpClient } from '@angular/common/http';
import { JwtService } from './jwt.service';
import { MessageService } from '../message/message.service';
import { UserService } from '../user/user.service';

@Injectable()
export class AuthService {

  private currentUser$ = new BehaviorSubject<User>(null);
  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private jwtService: JwtService,
    private errorHandlingService: ErrorHandlingService,
    private userService: UserService) { 
      this.url = 'https://localhost:5001' + '/api/Authorisation/';      
    }

  public isSignedIn(): boolean {

    return !this.jwtService.isExpired();
  }

  public signIn(loginModel: UserLoginModel): Observable<User> {
    let PATH = this.url +'SignIn';

    return this.httpClient.post<any>(PATH, loginModel).pipe(
      tap(({user, token}) => {
        this.jwtService.persistToken(token);
        this.currentUser$.next(user as User);
        this.messageService.add('Authorization was successful.');

        
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

        this.messageService.add('Registration was successful.');
      }),
      catchError(this.errorHandlingService.handleError)
    );
  }

  public signOut(): Observable<void> {
    this.currentUser$.next(null);
    this.jwtService.clearToken();
    return of(null);
  }

  public getCurrentUser(): Observable<User> {
    let token = this.jwtService.getDecodedAccessToken(this.jwtService.getRawToken());
    if(token != null && !this.jwtService.isExpired())
    {
      return this.userService.getUser(token.sub);
    }
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    if(localStorage.get('token'))
        return true;
    else
        return false;
   }
}