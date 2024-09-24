import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TraincreateComponent } from './traincreate.component';

describe('TraincreateComponent', () => {
  let component: TraincreateComponent;
  let fixture: ComponentFixture<TraincreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TraincreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TraincreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
