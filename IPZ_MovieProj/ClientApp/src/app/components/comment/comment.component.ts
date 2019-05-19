import { Component, OnInit, Input } from '@angular/core';
import { CommentFilm } from '../../models/commentFilm';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Film } from '../../models/film';
import { CommentService } from '../../services/comment/comment.service';
import { filterQueryId } from '@angular/core/src/view/util';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  constructor(private commentService: CommentService) { }

  comment: CommentFilm;
  @Input() filmId : number;

  ngOnInit() {
    this.newFilm();
  }

  sendComment() : void{
    this.commentService.addComment(this.comment);
    this.newFilm();
  }

  newFilm() : void{
    this.comment = new CommentFilm();
    this.comment.filmId = this.filmId;
  }

}
