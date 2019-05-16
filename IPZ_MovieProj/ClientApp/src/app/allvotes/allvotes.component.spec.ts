import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllvotesComponent } from './allvotes.component';

describe('AllvotesComponent', () => {
  let component: AllvotesComponent;
  let fixture: ComponentFixture<AllvotesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllvotesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllvotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
