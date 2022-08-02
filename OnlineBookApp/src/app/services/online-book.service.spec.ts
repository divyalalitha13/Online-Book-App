import { TestBed } from '@angular/core/testing';

import { OnlineBookService } from './online-book.service';

describe('OnlineBookService', () => {
  let service: OnlineBookService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OnlineBookService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
