import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainupdateComponent } from './trainupdate.component';

describe('TrainupdateComponent', () => {
  let component: TrainupdateComponent;
  let fixture: ComponentFixture<TrainupdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainupdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
