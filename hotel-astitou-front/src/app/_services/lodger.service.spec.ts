import { TestBed } from '@angular/core/testing';

import { LodgerService } from './lodger.service';

describe('LodgerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LodgerService = TestBed.get(LodgerService);
    expect(service).toBeTruthy();
  });
});
