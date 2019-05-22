import { Injectable } from '@angular/core';
import { MessageService } from '../message/message.service';
import { ErrorHandlingService } from '../authorisation/error-handling.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  private user : User; 
  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private errorHandlingService: ErrorHandlingService) { 
      this.url = 'https://localhost:5001' + '/api/user';
    }

  getUser(id : string) : Observable<User> {
    let PATH = this.url + '/' + id;

    this.messageService.add('UserService: fetched user ' + id);

    return this.httpClient.get<User>(PATH);
  }
}
