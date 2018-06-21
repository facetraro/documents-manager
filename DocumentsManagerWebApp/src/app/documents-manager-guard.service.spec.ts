import { TestBed, inject } from '@angular/core/testing';

import { DocumentsManagerGuardService } from './documents-manager-guard.service';

describe('DocumentsManagerGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DocumentsManagerGuardService]
    });
  });

  it('should be created', inject([DocumentsManagerGuardService], (service: DocumentsManagerGuardService) => {
    expect(service).toBeTruthy();
  }));
});
