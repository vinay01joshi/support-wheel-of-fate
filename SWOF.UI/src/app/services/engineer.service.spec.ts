import { TestBed, inject } from '@angular/core/testing';

import { EngineerService } from './engineer.service';

describe('EngineerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EngineerService]
    });
  });

  it('should be created', inject([EngineerService], (service: EngineerService) => {
    expect(service).toBeTruthy();
  }));
});
