import { Component, OnInit, Input } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Film } from '../../models/film';
import { CommentService } from '../../services/comment/comment.service';
import { filterQueryId } from '@angular/core/src/view/util';
import { AuthService } from 'src/app/services/authorisation/authorisation.service';
import { MessageService } from 'src/app/services/message/message.service';

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
  @Input() filmId : number;

  ngOnInit() {
    this.newComment();
  }

   sendComment() : void{
     this.commentService.addComment(this.comment);
     this.newComment();
   }

  newComment() : void{
    this.comment = new CommentFilm();
    this.comment.filmId = this.filmId;
    if (!this.authService.isSignedIn())
    {
      this.messageService.add("You`re not signed in");
      return;
    }
    this.authService.getCurrentUser()
          .subscribe(user => this.comment.userId = user.id);
  }

}
