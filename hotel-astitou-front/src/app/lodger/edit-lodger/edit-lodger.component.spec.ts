import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLodgerComponent } from './edit-lodger.component';

describe('EditLodgerComponent', () => {
  let component: EditLodgerComponent;
  let fixture: ComponentFixture<EditLodgerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditLodgerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditLodgerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
