import { Component, OnInit } from '@angular/core';
import { Film } from '../models/film';

@Component({
  selector: 'app-topfilms',
  templateUrl: './topfilms.component.html',
  styleUrls: ['./topfilms.component.css']
})
export class TopfilmsComponent implements OnInit {

  film: Film;

  constructor() { }

  ngOnInit() {
  }

}
