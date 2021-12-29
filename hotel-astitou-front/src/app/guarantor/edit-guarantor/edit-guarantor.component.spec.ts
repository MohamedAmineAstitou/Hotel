import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGuarantorComponent } from './edit-guarantor.component';

describe('EditGuarantorComponent', () => {
  let component: EditGuarantorComponent;
  let fixture: ComponentFixture<EditGuarantorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditGuarantorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditGuarantorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
