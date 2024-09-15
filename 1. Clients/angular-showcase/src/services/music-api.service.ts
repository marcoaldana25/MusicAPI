import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProfile } from '../app/modules/data-models/userProfile';
import { Observable } from 'rxjs';
import { SearchResult } from '../app/modules/data-models/searchResult';

@Injectable({
  providedIn: 'root'
})
export class MusicApiService {

  constructor(private http: HttpClient) { }

  getAccountDetails(): Observable<UserProfile> {
    let url = 'http://localhost:8080/api/Users/accountDetails'

    return this.http.get<UserProfile>(url);
  }

  getArtistSearch(searchQuery: string, marketCode: string, limit: number): Observable<SearchResult> {
    let url = 'http://localhost:8080/api/Artist/search?searchQuery=' + searchQuery + '&marketCode=' + marketCode + '&limit=' + limit;

    return this.http.get<SearchResult>(url);
  }
}
