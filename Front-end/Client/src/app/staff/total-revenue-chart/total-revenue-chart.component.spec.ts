import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalRevenueChartComponent } from './total-revenue-chart.component';

describe('TotalRevenueChartComponent', () => {
  let component: TotalRevenueChartComponent;
  let fixture: ComponentFixture<TotalRevenueChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TotalRevenueChartComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TotalRevenueChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
