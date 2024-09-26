import { TestBed } from '@angular/core/testing';

import { DailycashService } from './dailycash.service';

describe('DailycashService', () => {
  let service: DailycashService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DailycashService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
