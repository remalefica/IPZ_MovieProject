import { Injectable } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { of, Observable } from 'rxjs';
import { MessageService } from '../message/message.service';
import { ErrorHandlingService } from '../authorisation/error-handling.service';
import { HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  
  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private errorHandlingService: ErrorHandlingService) { 
      this.url = 'https://localhost:5001' + '/api/Comment';
    }

  getCommentsByFilmId(filmId : number) : Observable<CommentFilm[]> {
    let PATH = this.url +'/film/' + `${filmId}`;

    this.messageService.add('CommentService: fetched comments of film ' + `${filmId}`);

    return this.httpClient.get<CommentFilm[]>(PATH);
}

  addComment(comment : CommentFilm): Observable<CommentFilm>{
    let PATH = this.url + '/Create';

    return this.httpClient.post<CommentFilm>(PATH, {
      id: comment.id,
      filmId: comment.filmId,
      userId: comment.userId,
      text: comment.text
    })
        .pipe(
          tap(() => {
            this.messageService.add('CommentService: fetched comments of film ' + `${comment.userId}` + `${comment.text}`);
          }),
          catchError(this.errorHandlingService.handleError)
          );
  }
}

