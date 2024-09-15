import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  aboutMeVisible: boolean = true;
  spotifyVisible: boolean = false;

  aboutMeText: string = 'See Less About Me';
  musicApiText: string = 'Checkout my Music API';

  ngOnInit(): void {
  }

  showHideAboutMe(): void {
    this.aboutMeVisible = this.aboutMeVisible ? false : true;
    this.aboutMeText = this.aboutMeVisible ? "See Less About Me" : "A Little About Me";
  }

  showHideSpotify(): void {
    this.spotifyVisible = this.spotifyVisible ? false : true;
    this.musicApiText = this.spotifyVisible ? "No Thanks Spotify" : "Checkout my Music API";
  }
}
