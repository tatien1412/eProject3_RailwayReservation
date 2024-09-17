import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationcreateComponent } from './stationcreate.component';

describe('StationcreateComponent', () => {
  let component: StationcreateComponent;
  let fixture: ComponentFixture<StationcreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StationcreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StationcreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
