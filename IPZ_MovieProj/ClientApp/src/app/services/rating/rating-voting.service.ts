import { Injectable } from '@angular/core';
import { VoteFilm } from '../../models/voteFilm';
import { of, Observable } from 'rxjs';
import { MessageService } from '../message/message.service';
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from '../authorisation/error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class RatingVotingService {

  private url : string;

  constructor(private messageService: MessageService,
    private httpClient: HttpClient,
    private errorHandlingService: ErrorHandlingService) { 
      this.url = 'https://localhost:5001' + '/api/vote';
    }

  getFilmUserVote(filmId : number, userId : string) : Observable<VoteFilm> {
    let PATH = this.url +'/film/' + `${filmId}` + '/user/' + userId;

    this.messageService.add('FilmService: fetched films');

    return this.httpClient.get<VoteFilm>(PATH);
  }

  addVote(rating : VoteFilm) : Observable<VoteFilm>{
    let PATH = this.url +'/make-vote';

    return this.httpClient.post<VoteFilm>(PATH, rating)
  }

  updateVote(id : number, rating : VoteFilm) : Observable<VoteFilm>{
    let PATH = this.url +'/update-vote/' + `${id}`;

    return this.httpClient.put<VoteFilm>(PATH, rating);
  }

}

