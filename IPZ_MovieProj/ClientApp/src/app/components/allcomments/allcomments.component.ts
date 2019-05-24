import { Component, OnInit } from '@angular/core';
import { User, CommentFilm, Film } from 'src/app/models';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/authorisation/authorisation.service';
import { CommentService } from 'src/app/services/comment/comment.service';
import { FilmService } from 'src/app/services/film/film.service';

@Component({
  selector: 'app-allcomments',
  templateUrl: './allcomments.component.html',
  styleUrls: ['./allcomments.component.css']
})
export class AllcommentsComponent implements OnInit {

  user : User;
  comments : CommentFilm[];

  constructor(private router: Router, 
              private authService: AuthService,
              private commentService: CommentService,
              private filmService: FilmService) { }

  ngOnInit() {
    this.getUserInfo();
  }

  getUserInfo() : void{
    this.authService.getCurrentUser()
      .subscribe(userAuth => {
        this.user = userAuth;
        this.commentService.getCommentByUserId(this.user.id)
        .subscribe(commentsDb => 
          {this.comments = commentsDb;
  
            this.comments.forEach(comment => {
              this.filmService.getFilm(comment.filmId)
                 .subscribe(film => comment.film = film);
                 });});});


  }
}
