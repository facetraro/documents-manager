import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewStyleComponent } from './new-style.component';

describe('NewStyleComponent', () => {
  let component: NewStyleComponent;
  let fixture: ComponentFixture<NewStyleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewStyleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewStyleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
