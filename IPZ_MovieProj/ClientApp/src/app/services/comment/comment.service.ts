import { Injectable } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { of, Observable } from 'rxjs';
import { MessageService } from '../message/message.service';
import { ErrorHandlingService } from '../authorisation/error-handling.service';
import { HttpClient } from '@angular/common/http';

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

    this.messageService.add('COmmentService: fetched comments of film ' + `${filmId}`);

    return this.httpClient.get<CommentFilm[]>(PATH);
}

  /*getComments(filmId: number) : Observable<CommentFilm[]>{
    return of(this.comments
      .filter(comment => comment.filmId == filmId));
  }

  addComment(comment : CommentFilm): void{
    this.comments.push(comment);
  }*/

}

export const CommentsMock : CommentFilm[] = [

  {id: 1, filmId: 1, userId: 1, text: 'Great film, liked a lot', createdAt: new Date(2011, 0, 1, 0, 0, 0, 0)},
  {id: 2, filmId: 1, userId: 2, text: 'Great film', createdAt: new Date(2012, 0, 1, 0, 0, 0, 0)},
  {id: 3, filmId: 2, userId: 1, text: 'Liked a lot', createdAt: new Date(2013, 0, 1, 0, 0, 0, 0)},
  {id: 4, filmId: 2, userId: 2, text: 'Great', createdAt: new Date(2014, 0, 1, 0, 0, 0, 0)},
  {id: 5, filmId: 3, userId: 1, text: 'Great, liked a lot', createdAt: new Date(2015, 0, 1, 0, 0, 0, 0)},
  {id: 6, filmId: 3, userId: 2, text: 'Great, liked', createdAt: new Date(2016, 0, 1, 0, 0, 0, 0)},
]
