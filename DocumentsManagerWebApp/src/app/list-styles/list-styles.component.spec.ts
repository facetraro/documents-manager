import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListStylesComponent } from './list-styles.component';

describe('ListStylesComponent', () => {
  let component: ListStylesComponent;
  let fixture: ComponentFixture<ListStylesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListStylesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListStylesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
