import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TraindeleteComponent } from './traindelete.component';

describe('TraindeleteComponent', () => {
  let component: TraindeleteComponent;
  let fixture: ComponentFixture<TraindeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TraindeleteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TraindeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
