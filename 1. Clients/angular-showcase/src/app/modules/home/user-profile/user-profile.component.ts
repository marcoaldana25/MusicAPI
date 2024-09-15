import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../../data-models/userProfile';
import { MusicApiService } from '../../../../services/music-api.service';

@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit {
  userProfile: UserProfile = new UserProfile();

  userProfileVisible: boolean = false;
  userProfileText: string = 'Show me yo';


  ngOnInit(): void {
    this.musicApiService
      .getAccountDetails()
      .subscribe((accountDetails) => {
        this.userProfile = accountDetails;
      });
  }

  showHideUserProfile(): void {
    this.userProfileVisible = this.userProfileVisible ? false : true;
    this.userProfileText = this.userProfileVisible ? "No one cares" : "Wait, let me see that again";
  }

  constructor(private musicApiService: MusicApiService) {  }
}
