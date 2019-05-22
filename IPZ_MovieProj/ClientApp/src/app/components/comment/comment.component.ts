import { Component, OnInit, Input } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Film } from '../../models/film';
import { CommentService } from '../../services/comment/comment.service';
import { AuthService } from 'src/app/services/authorisation/authorisation.service';
import { MessageService } from 'src/app/services/message/message.service';
import { Observable } from 'rxjs';
import { User } from 'src/app/models';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  constructor(private commentService: CommentService,
              private authService: AuthService,
              private messageService: MessageService) { }

  comment: CommentFilm;
  user : User;
  @Input() filmId : number;

  ngOnInit() {
    this.authService.getCurrentUser()
    .subscribe(userDb => this.user = userDb);
    this.newComment();
  }

   addComment() : void{
    this.comment.userId = this.user.id;
    this.comment.filmId = this.filmId;
    this.commentService.addComment(this.comment);
    this.newComment();
   }

  newComment() : void{
    this.comment = new CommentFilm();
  }

  public get isUserSignedIn$(): Observable<boolean> {
    return this.authService.isSignedIn();
  }

}
