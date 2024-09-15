import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserProfileComponent } from './user-profile.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { MusicApiService } from '../../../../services/music-api.service';
import { Type } from '@angular/core';
import { UserProfile } from '../../data-models/userProfile';
import { of } from 'rxjs';


describe('UserProfileComponent', () => {
  let component: UserProfileComponent;
  let fixture: ComponentFixture<UserProfileComponent>;
  let httpMock: HttpTestingController;

  let userProfile = new UserProfile();
  userProfile.country = "USA";
  userProfile.displayName = "Display Name";

  const musicApiServiceStub = jasmine.createSpyObj('MusicApiService', ['getAccountDetails']);
  let getAccountDetailsSpy = musicApiServiceStub.getAccountDetails.and.returnValue(of(userProfile));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      // Inject HttpClientTestingModule since it's a dependency for MusicAPI Service downstream
      imports: [
        HttpClientTestingModule
      ],
      // The component that is being tested
      declarations: [
        UserProfileComponent
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
    
    fixture = TestBed.createComponent(UserProfileComponent);
    component = fixture.componentInstance;
    httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call getAccountDetails on init', () => {
    // OnInit()
    fixture.detectChanges();

    // Expect component instance userProfile to match the blank
    expect(component.userProfile).toBe(userProfile);
    expect(component.userProfile.country).toBe("USA");
    expect(component.userProfile.displayName).toBe("Display Name");

    expect(getAccountDetailsSpy.calls.any()).withContext('getAccountDetails called').toBe(true);
  });
});
