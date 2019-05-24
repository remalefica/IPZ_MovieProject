import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MessageService } from '../message/message.service';
import { Film } from '../../models/film';
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from '../authorisation/error-handling.service';
import { catchError } from 'rxjs/operators';
import { Genre } from 'src/app/models';

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

    return this.httpClient.get<Film[]>(PATH);
}

getTop() : Observable<Film[]> {
  let PATH = this.url +'/topfive';

  this.messageService.add('FilmService: fetched top films');

  return this.httpClient.get<Film[]>(PATH);
}

getFilm(id: number): Observable<Film> {
  let PATH = this.url + `/${id}`;

  return this.httpClient.get<Film>(PATH);
}

getByGenre(genre: number): Observable<Film[]> {

  let PATH = this.url + `/genre/${genre}`;

  return this.httpClient.get<Film[]>(PATH);
}

}
