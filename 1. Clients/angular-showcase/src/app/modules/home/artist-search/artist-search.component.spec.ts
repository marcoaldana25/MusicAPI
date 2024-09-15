import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistSearchComponent } from './artist-search.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { MusicApiService } from '../../../../services/music-api.service';
import { SearchResult } from '../../data-models/searchResult';
import { of } from 'rxjs';
import { Artists } from '../../data-models/artists';
import { Type } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ArtistCardComponent } from '../artist-card/artist-card.component';

describe('ArtistSearchComponent', () => {
  let component: ArtistSearchComponent;
  let fixture: ComponentFixture<ArtistSearchComponent>;
  let httpMock: HttpTestingController;

  let mockArtistSearch = new SearchResult();
  mockArtistSearch.artists = new Artists();

  mockArtistSearch.artists.total = 10;

  const musicApiServiceStub = jasmine.createSpyObj('MusicApiService', ['getArtistSearch']);
  let getArtistSearchSpy = musicApiServiceStub.getArtistSearch.and.returnValue(of(mockArtistSearch));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        // Inject dependencies needed for MusicAPI Service
        HttpClientTestingModule,
        ReactiveFormsModule
      ],
      declarations: [
        // The actual component being tested
        ArtistSearchComponent,
        ArtistCardComponent
      ],
      // API Service setup with mock stub
      providers: [
        {
          provide: MusicApiService,
          useValue: musicApiServiceStub
        }
      ]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ArtistSearchComponent);
    component = fixture.componentInstance;
    httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should populate artist search result OnSubmit', () => {
    component.formGroup.setValue({
      artistSearch: 'artistSearch',
      marketCode: 'ES',
      limit: '1'
    });

    component.onSubmit();

    expect(component.artistSearchResult).toBe(mockArtistSearch);

    expect(component.artistSearchResult.artists.total).toBe(10);

    expect(getArtistSearchSpy.calls.any()).withContext('getArtistSearch called').toBe(true);
  });
});
