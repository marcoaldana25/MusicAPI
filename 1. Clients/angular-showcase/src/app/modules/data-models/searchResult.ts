import { Artists } from "./artists";

export class SearchResult {
  constructor() {
    this.artists = new Artists();
  }

  artists: Artists;
}
