import { Component, OnInit, Input } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { CommentService} from '../../services/comment/comment.service';
import { Film } from '../../models/film';
import { UserService } from 'src/app/services/user/user.service';
import { User } from 'src/app/models';
import { AuthService } from 'src/app/services/authorisation/authorisation.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent implements OnInit {


  comments : CommentFilm[];
  comment: CommentFilm;
  user : User;
  @Input() filmId : number;

  constructor(private commentService: CommentService,
              private userService: UserService,
              private authService: AuthService) { }

  ngOnInit() {
    this.getComments();
    if(this.authService.isSignedIn()){
    this.authService.getCurrentUser()
    .subscribe(userDb => {
      this.user = userDb;
      this.comment.username = userDb.username;
    });
    this.newComment();
  }
  }

  addComment() : void{
    this.comment.userId = this.user.id;
    this.comment.filmId = this.filmId;
    this.comment.username = this.user.username;
    this.commentService.addComment(this.comment)
      .subscribe();
    this.comments.push(this.comment)
    this.newComment();
   }

  newComment() : void{
    this.comment = new CommentFilm();
  }

  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }

 getComments(): void{
    this.commentService.getCommentsByFilmId(this.filmId)
          .subscribe(comments => {
            this.comments = comments;

            this.comments.forEach(comment => {
              this.userService.getUser(comment.userId)
                .subscribe(user => comment.username = user.username);
            });
          });


  }

}
