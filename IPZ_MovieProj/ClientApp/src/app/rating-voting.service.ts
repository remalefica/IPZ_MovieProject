import { Injectable } from '@angular/core';
import { VoteFilm } from './voteFilm';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RatingVotingService {

  votes = VotesMock;

  getVotes(filmId: number) : Observable<VoteFilm[]>{
    return of(this.votes
      .filter(vote => vote.filmId == filmId));
  }

  addVote(rating : VoteFilm): void{
    this.votes.push(rating);
  }

}

export const VotesMock : VoteFilm[] = [
  {filmId: 1, rating: 5},
  { filmId: 1, rating: 4},
]
