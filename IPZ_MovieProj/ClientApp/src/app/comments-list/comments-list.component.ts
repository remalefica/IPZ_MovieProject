import { Component, OnInit, Input } from '@angular/core';
import { CommentFilm } from '../models/commentFilm';
import { CommentService, CommentsMock } from '../services/comment/comment.service';
import { Film } from '../models/film';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent implements OnInit {

  comments : CommentFilm[];

  @Input() filmId: number;

  constructor(private commentService: CommentService) { }

  ngOnInit() {
    this.getComments();
  }

 getComments(): void{
    this.commentService.getComments(this.filmId)
          .subscribe(comments => this.comments = comments);
  }

}
