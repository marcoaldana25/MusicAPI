import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route } from '@angular/router';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { ArtistSearchComponent } from './artist-search/artist-search.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ArtistCardComponent } from './artist-card/artist-card.component';
import { AboutMeComponent } from './about-me/about-me.component';

const homeRoutes: Route[] = [{
  path: '',
  component: HomeComponent
}]

@NgModule({
  declarations: [
    AboutMeComponent,
    ArtistCardComponent,
    ArtistSearchComponent,
    HomeComponent,
    UserProfileComponent
  ],
  imports: [
    RouterModule.forChild(homeRoutes),
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class HomeModule { }
