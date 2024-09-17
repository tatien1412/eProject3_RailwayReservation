import { TestBed } from '@angular/core/testing';

import { TrainRouteService } from './train-route.service';

describe('TrainRouteService', () => {
  let service: TrainRouteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainRouteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
