import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationdetailComponent } from './stationdetail.component';

describe('StationdetailComponent', () => {
  let component: StationdetailComponent;
  let fixture: ComponentFixture<StationdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StationdetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StationdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
