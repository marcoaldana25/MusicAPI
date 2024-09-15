import { Artists } from '../app/modules/data-models/artists';
import { SearchResult } from '../app/modules/data-models/searchResult';
import { UserProfile } from '../app/modules/data-models/userProfile';
import { MusicApiService } from './music-api.service';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';

describe('MusicApiService', () => {
  let musicApiService: MusicApiService;
  let httpClientSpy: jasmine.SpyObj<HttpClient>;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    musicApiService = new MusicApiService(httpClientSpy);
  });

  it('should be created', () => {
    expect(musicApiService).toBeTruthy();
  });

  it('getAccountDetails - should return UserProfile', (done: DoneFn) => {
    const expectedUserProfile = new UserProfile();
    expectedUserProfile.country = "USA";
    expectedUserProfile.displayName = "Display Name";

    httpClientSpy.get.and.returnValue(of(expectedUserProfile));

    musicApiService
      .getAccountDetails()
      .subscribe({
        next: (accountDetails) => {
          expect(accountDetails).withContext('expected account details').toEqual(expectedUserProfile);
          done();
        },
        error: done.fail
      });

    expect(httpClientSpy.get.calls.count()).withContext('one call').toBe(1);
  });

  it('getArtistSearch - should return SearchResult', (done: DoneFn) => {
    const expectedSearchResult = new SearchResult();
    expectedSearchResult.artists = new Artists();
    expectedSearchResult.artists.href = "Href";
    expectedSearchResult.artists.limit = 10;

    httpClientSpy.get.and.returnValue(of(expectedSearchResult));

    musicApiService
      .getArtistSearch("searchQuery", "marketCode", 10)
      .subscribe({
        next: (searchResult) => {
          expect(searchResult).withContext('expected search result').toEqual(expectedSearchResult);
          done();
        },
        error: done.fail
      });

    expect(httpClientSpy.get.calls.count()).withContext('one call').toBe(1);
  });
});
