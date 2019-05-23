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

votes: VoteFilm;
@Input() rating: VoteFilm;
@Input() filmId: number;
          user : User;
@Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();
 
  ngOnInit() {
    this.authService.isSignedIn()
      .subscribe(isSignedIn =>
          {  
            this.authService.getCurrentUser()
              .subscribe( user =>
                this.user = user);

            if(isSignedIn){
                this.rating = new VoteFilm();
                this.getVote();

                this.ratingClick.emit({
                  rating: this.rating.rating
                });
              }
          });
  }
  onClick(ratingInput : number): void {

    this.ratingClick.emit({
      rating: ratingInput
    });
    this.sendVote(ratingInput);
  }

  ratingConstructor(ratingInput: number) : void{
    this.rating.filmId = this.filmId;
    this.rating.userId = this.user.id;
    this.rating.rating  = ratingInput;
  }

  sendVote(ratingInput : number) : void{

    if(this.rating == null){
      this.rating = new VoteFilm();
      this.ratingConstructor(ratingInput);

      this.ratingvotingService.addVote(this.rating)
      .subscribe();
    } 
    else{
      this.ratingConstructor(ratingInput);
      this.ratingvotingService.updateVote(this.rating.id, this.rating)
        .subscribe();
    }
  }

  public get isUserSignedIn$(): Observable<boolean> {
    return this.authService.isSignedIn();
  }

  getVote() : void{
      this.ratingvotingService.getFilmUserVote(this.filmId, this.user.id)
        .subscribe(vote => this.rating = vote);
  }

}
