import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MessageService } from '../message/message.service';
import { Film } from '../../models/film';
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from '../authorisation/error-handling.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class FilmService {
  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private errorHandlingService: ErrorHandlingService) { 
      this.url = 'https://localhost:5001' + '/api/Film';
    }

  getFilms() : Observable<Film[]> {
    let PATH = this.url +'/all';

    this.messageService.add('FilmService: fetched films');

    return this.httpClient.get<Film[]>(PATH);
}

getFilm(id: number): Observable<Film> {
  let PATH = this.url + `/${id}`;

  this.messageService.add('FilmService: fetched film id ' + `{${id}}`);
  return this.httpClient.get<Film>(PATH);
}
}
