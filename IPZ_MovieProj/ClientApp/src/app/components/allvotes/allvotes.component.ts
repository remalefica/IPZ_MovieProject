import { Component, OnInit } from '@angular/core';
import { User, VoteFilm, Film } from 'src/app/models';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/authorisation/authorisation.service';
import { RatingVotingService } from 'src/app/services/rating/rating-voting.service';
import { FilmService } from 'src/app/services/film/film.service';

@Component({
  selector: 'app-allvotes',
  templateUrl: './allvotes.component.html',
  styleUrls: ['./allvotes.component.css']
})
export class AllvotesComponent implements OnInit {

  user: User;
  votes: VoteFilm[];

  constructor(private router: Router, 
              private authService: AuthService,
              private voteService: RatingVotingService,
              private filmService: FilmService) { }

  ngOnInit() {
    this.getUserInfo();
  }

  getUserInfo() : void{
    this.authService.getCurrentUser()
      .subscribe(userAuth => {this.user = userAuth});

    this.voteService.getVoteByUserId(this.user.id)
      .subscribe(votesDb => 
        {this.votes = votesDb;

          this.votes.forEach(vote => {
            this.filmService.getFilm(vote.filmId)
               .subscribe(film => vote.film = film);
               });});
              }
}
