import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationsReportsPageComponent } from './operations-reports-page.component';

describe('OperationsReportsPageComponent', () => {
  let component: OperationsReportsPageComponent;
  let fixture: ComponentFixture<OperationsReportsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperationsReportsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationsReportsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
