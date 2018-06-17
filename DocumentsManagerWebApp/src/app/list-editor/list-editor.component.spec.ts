import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEditorsComponent } from './list-editor.component';

describe('ListEditorComponent', () => {
  let component: ListEditorsComponent;
  let fixture: ComponentFixture<ListEditorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListEditorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListEditorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
