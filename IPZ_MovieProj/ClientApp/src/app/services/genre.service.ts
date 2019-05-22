import { Injectable } from '@angular/core';
import { MessageService } from './message/message.service';
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from './authorisation/error-handling.service';
import { Observable } from 'rxjs';
import { Genre, GenreFilm } from '../models/genre';
import { Film } from '../models/film';


@Injectable({
  providedIn: 'root'
})
export class GenreService {
  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private errorHandlingService: ErrorHandlingService) { 
      this.url = 'https://localhost:5001' + '/api/genre';
    }
    
    getGenre(id: number): Observable<GenreFilm[]> {
      let PATH = this.url + `/film/${id}`;

      this.messageService.add('GenreService: fetched genre id ' + `{${id}}`);
      return this.httpClient.get<GenreFilm[]>(PATH);
    }

}
