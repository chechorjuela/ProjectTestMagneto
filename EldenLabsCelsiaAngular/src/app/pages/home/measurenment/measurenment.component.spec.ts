import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeasurenmentComponent } from './measurenment.component';

describe('MeasurenmentComponent', () => {
  let component: MeasurenmentComponent;
  let fixture: ComponentFixture<MeasurenmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MeasurenmentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MeasurenmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
