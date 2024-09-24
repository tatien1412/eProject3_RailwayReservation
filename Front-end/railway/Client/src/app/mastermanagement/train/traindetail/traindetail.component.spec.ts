import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TraindetailComponent } from './traindetail.component';

describe('TraindetailComponent', () => {
  let component: TraindetailComponent;
  let fixture: ComponentFixture<TraindetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TraindetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TraindetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
