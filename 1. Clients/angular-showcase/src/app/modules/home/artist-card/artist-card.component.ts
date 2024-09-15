import { Component, Input, OnInit } from '@angular/core';
import { Artists } from '../../data-models/artists';

@Component({
  selector: 'artist-card',
  templateUrl: './artist-card.component.html',
  styleUrl: './artist-card.component.css'
})
export class ArtistCardComponent implements OnInit {
  @Input() artists = new Artists();

  ngOnInit(): void {
  }
}
