import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { VoteFilm } from '../voteFilm'
import { RatingVotingService, VotesMock } from '../rating-voting.service';
import { Film } from '../film';

@Component({
  selector: 'app-rating-voting',
  templateUrl: './rating-voting.component.html',
  styleUrls: ['./rating-voting.component.css']
})
export class RatingVotingComponent implements OnInit {
  

constructor(private ratingvotingService : RatingVotingService){ }

votes: VoteFilm[];
@Input() rating: VoteFilm;
@Input() filmId: number;
@Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();
 
  ngOnInit() {
    this.newVote();
    this.getVotes();
   
  }
  onClick(rating : number): void {
    this.rating.rating = rating;
    this.ratingClick.emit();
    //this.sendVote();
  }

  sendVote() : void{
    this.ratingvotingService.addVote(this.rating);
    this.newVote();
  }

  newVote():void{
    this.rating = new VoteFilm();
    this.rating.filmId = this.filmId;
  }

  getVotes() : void{
    this.ratingvotingService.getVotes(this.filmId)
        .subscribe(votes => this.votes = votes);
  }

}
