import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListLodgerComponent } from './list-lodger.component';

describe('ListLodgerComponent', () => {
  let component: ListLodgerComponent;
  let fixture: ComponentFixture<ListLodgerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListLodgerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListLodgerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
