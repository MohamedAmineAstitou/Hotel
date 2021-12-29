import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLodgerComponent } from './add-lodger.component';

describe('AddLodgerComponent', () => {
  let component: AddLodgerComponent;
  let fixture: ComponentFixture<AddLodgerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLodgerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLodgerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
