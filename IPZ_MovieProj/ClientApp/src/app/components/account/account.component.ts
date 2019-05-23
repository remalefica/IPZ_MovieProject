import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/authorisation/authorisation.service';
import { User, CommentFilm, VoteFilm, Film } from '../../models';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/services/user/user.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { CommentService } from 'src/app/services/comment/comment.service';
import { RatingVotingService } from 'src/app/services/rating/rating-voting.service';
import { RatingVotingComponent } from '../rating-voting/rating-voting.component';
import { FilmService } from 'src/app/services/film/film.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  user : User;
  comment: CommentFilm;
  filmComment: Film;
  vote: VoteFilm;

  constructor(private router: Router, 
              private authService: AuthService,
              private commentService: CommentService,
              private voteService: RatingVotingService,
              private filmService: FilmService) { }

  ngOnInit() {
    this.getUserInfo();
  }

  getUserInfo() : void{
    this.authService.getCurrentUser()
      .subscribe(userAuth => {this.user = userAuth});

    this.commentService.getCommentByUserIdLast(this.user.id)
      .subscribe(commentDb => 
        {this.comment = commentDb;
          this.filmService.getFilm(this.comment.filmId)
          .subscribe(film => 
            this.filmComment = film);})



  }
}
