import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewFormatComponent } from './new-format.component';

describe('NewFormatComponent', () => {
  let component: NewFormatComponent;
  let fixture: ComponentFixture<NewFormatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewFormatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewFormatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
