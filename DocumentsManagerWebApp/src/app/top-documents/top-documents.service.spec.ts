import { TestBed, inject } from '@angular/core/testing';

import { TopDocumentsService } from './top-documents.service';

describe('TopDocumentsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TopDocumentsService]
    });
  });

  it('should be created', inject([TopDocumentsService], (service: TopDocumentsService) => {
    expect(service).toBeTruthy();
  }));
});
