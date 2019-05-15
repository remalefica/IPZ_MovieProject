import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/authorisation/authorisation.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-authorisation',
  templateUrl: './authorisation.component.html',
  styleUrls: ['./authorisation.component.css']
})
export class AuthorisationComponent implements OnInit {

  constructor(    
    private route: ActivatedRoute) { }

  ngOnInit() {
  }

}
