import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddResComponent } from './add-res.component';

describe('AddResComponent', () => {
  let component: AddResComponent;
  let fixture: ComponentFixture<AddResComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddResComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddResComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
