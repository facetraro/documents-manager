import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFormatComponent } from './list-format.component';

describe('ListFormatComponent', () => {
  let component: ListFormatComponent;
  let fixture: ComponentFixture<ListFormatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListFormatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListFormatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
