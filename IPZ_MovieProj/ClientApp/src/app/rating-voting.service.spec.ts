import { TestBed, inject } from '@angular/core/testing';

import { RatingVotingService } from './rating-voting.service';

describe('RatingVotingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RatingVotingService]
    });
  });

  it('should be created', inject([RatingVotingService], (service: RatingVotingService) => {
    expect(service).toBeTruthy();
  }));
});
