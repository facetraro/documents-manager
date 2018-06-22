import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyFormatComponent } from './modify-format.component';

describe('ModifyFormatComponent', () => {
  let component: ModifyFormatComponent;
  let fixture: ComponentFixture<ModifyFormatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyFormatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyFormatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
