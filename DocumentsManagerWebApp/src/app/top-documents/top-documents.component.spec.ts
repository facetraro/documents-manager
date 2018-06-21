import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopDocumentsComponent } from './top-documents.component';

describe('TopDocumentsComponent', () => {
  let component: TopDocumentsComponent;
  let fixture: ComponentFixture<TopDocumentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopDocumentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopDocumentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
