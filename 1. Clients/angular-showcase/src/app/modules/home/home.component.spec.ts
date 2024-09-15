import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.component';
import { ArtistSearchComponent } from './artist-search/artist-search.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ArtistCardComponent } from './artist-card/artist-card.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { MusicApiService } from '../../../services/music-api.service';
import { Type } from '@angular/core';
import { of } from 'rxjs';
import { UserProfile } from '../data-models/userProfile';
import { ReactiveFormsModule } from '@angular/forms';
import { AboutMeComponent } from './about-me/about-me.component';

// This UnitTest will test all downstream dependencies. As components are added, this test will probably
// need to be updated as well with any new dependencies.
describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let httpMock: HttpTestingController;

  const musicApiServiceStub = jasmine.createSpyObj('MusicApiService', ['getAccountDetails']);
  let getAccountDetailsSpy = musicApiServiceStub.getAccountDetails.and.returnValue(of(new UserProfile()));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        ReactiveFormsModule
      ],
      declarations: [
        AboutMeComponent,
        HomeComponent,
        UserProfileComponent,
        ArtistSearchComponent,
        ArtistCardComponent
      ],
      providers: [
        {
          provide: MusicApiService,
          useValue: musicApiServiceStub
        }
      ]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
