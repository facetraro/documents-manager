import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyStyleComponent } from './modify-style.component';

describe('ModifyStyleComponent', () => {
  let component: ModifyStyleComponent;
  let fixture: ComponentFixture<ModifyStyleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyStyleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyStyleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
