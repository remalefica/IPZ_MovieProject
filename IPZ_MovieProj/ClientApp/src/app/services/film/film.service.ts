import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MessageService } from '../message/message.service';
import { Film } from '../../models/film';
import { FILMS } from '../../mock-films';
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from '../authorisation/error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class FilmService {

  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private errorHandlingService: ErrorHandlingService,
    @Inject('BASE_URL') baseUrl: string) { 
      this.url = baseUrl + 'api/film/';
    }

  getFilms(): Observable<Film[]> {
    let PATH = this.url +'all';

    this.messageService.add('FilmService: fetched films');

    return this.httpClient.get<Film[]>(PATH);
}

getFilm(id: number):  Observable<Film> {
  let PATH = this.url + `${id}`;

  return this.httpClient.get<Film>(PATH);
}
}
