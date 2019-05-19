import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingVotingComponent } from './rating-voting.component';

describe('RatingVotingComponent', () => {
  let component: RatingVotingComponent;
  let fixture: ComponentFixture<RatingVotingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RatingVotingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RatingVotingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
