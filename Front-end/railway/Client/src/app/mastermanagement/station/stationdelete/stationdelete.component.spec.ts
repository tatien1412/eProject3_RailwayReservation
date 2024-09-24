import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationdeleteComponent } from './stationdelete.component';

describe('StationdeleteComponent', () => {
  let component: StationdeleteComponent;
  let fixture: ComponentFixture<StationdeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StationdeleteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StationdeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
