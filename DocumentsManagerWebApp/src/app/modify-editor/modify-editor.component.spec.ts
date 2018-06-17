import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyEditorComponent } from './modify-editor.component';

describe('ModifyEditorComponent', () => {
  let component: ModifyEditorComponent;
  let fixture: ComponentFixture<ModifyEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
