import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopfilmsComponent } from './topfilms.component';

describe('TopfilmsComponent', () => {
  let component: TopfilmsComponent;
  let fixture: ComponentFixture<TopfilmsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopfilmsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopfilmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
