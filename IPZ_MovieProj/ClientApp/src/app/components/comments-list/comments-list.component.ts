import { Component, OnInit, Input } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { CommentService} from '../../services/comment/comment.service';
import { Film } from '../../models/film';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent implements OnInit {


  comments : CommentFilm[];

  @Input() filmId: number;

  constructor(private commentService: CommentService,
              private userService: UserService) { }

  ngOnInit() {
    this.getComments();
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
