import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationupdateComponent } from './stationupdate.component';

describe('StationupdateComponent', () => {
  let component: StationupdateComponent;
  let fixture: ComponentFixture<StationupdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StationupdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StationupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
