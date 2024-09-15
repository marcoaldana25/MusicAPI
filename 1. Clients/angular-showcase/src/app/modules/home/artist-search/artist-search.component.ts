import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MusicApiService } from '../../../../services/music-api.service';
import { SearchResult } from '../../data-models/searchResult';

@Component({
  selector: 'artist-search',
  templateUrl: './artist-search.component.html',
  styleUrl: './artist-search.component.css'
})
export class ArtistSearchComponent implements OnInit {
  formGroup = new FormGroup({
    artistSearch: new FormControl('', [Validators.required]),
    marketCode: new FormControl('', [Validators.required]),
    limit: new FormControl('', [Validators.required])
  })

  artistSearchResult: SearchResult = new SearchResult();

  constructor(private musicApiService: MusicApiService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.formGroup.markAllAsTouched();

    this.musicApiService
      .getArtistSearch(this.artistSearch?.getRawValue(), this.marketCode?.getRawValue(), this.limit?.getRawValue())
      .subscribe((searchResult) => {
        this.artistSearchResult = searchResult;
      });
  }

  get artistSearch() {
    return this.formGroup.get('artistSearch');
  }

  get marketCode() {
    return this.formGroup.get('marketCode');
  }

  get limit() {
    return this.formGroup.get('limit');
  }
}
