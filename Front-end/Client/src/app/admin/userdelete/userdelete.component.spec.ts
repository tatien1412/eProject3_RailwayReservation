import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserdeleteComponent } from './userdelete.component';

describe('UserdeleteComponent', () => {
  let component: UserdeleteComponent;
  let fixture: ComponentFixture<UserdeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserdeleteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserdeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
