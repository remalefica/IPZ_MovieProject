import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { VoteFilm } from '../../models/voteFilm'
import { RatingVotingService} from '../../services/rating/rating-voting.service';
import { AuthService } from 'src/app/services/authorisation/authorisation.service';
import { Observable } from 'rxjs';
import { User } from 'src/app/models';


@Component({
  selector: 'app-rating-voting',
  templateUrl: './rating-voting.component.html',
  styleUrls: ['./rating-voting.component.css']
})
export class RatingVotingComponent implements OnInit {
  

constructor(private ratingvotingService : RatingVotingService,
            private authService : AuthService){ }

vote: VoteFilm;
@Input() rating: number;
@Input() filmId: number;
          user : User;
@Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();
 
  ngOnInit() {
    if(this.authService.isSignedIn()){
            this.authService.getCurrentUser()
              .subscribe( user =>{
                this.user = user;
                this.vote = new VoteFilm();
                this.getVote();});
     }
  }

  onClick(rating : number): void {

    this.rating = rating;
    this.ratingClick.emit({
      rating: rating
    });
    this.sendVote(rating);
  }

  ratingConstructor(ratingInput: number) : void{
    this.vote.filmId = this.filmId;
    this.vote.userId = this.user.id;
    this.vote.rating  = this.rating;
  }

  sendVote(ratingInput : number) : void{

    if(this.vote.id == null){
      this.vote = new VoteFilm();
      this.ratingConstructor(ratingInput);

      this.ratingvotingService.addVote(this.vote)
      .subscribe();
    } 
    else{
      this.ratingConstructor(ratingInput);
      this.ratingvotingService.updateVote(this.vote.id, this.vote)
        .subscribe();
    }
  }

  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }

  getVote() : void{
      this.ratingvotingService.getFilmUserVote(this.filmId, this.user.id)
        .subscribe(vote => {this.vote = vote;
            this.rating = this.vote.rating});
  }

}
