import { ExternalUrl } from "./externalUrl";
import { Followers } from "./followers";
import { Image } from "./image";

export class Artist {
  constructor() {
    this.externalUrl = new ExternalUrl();
    this.followers = new Followers();
    this.genres = [];
    this.href = '';
    this.id = '';
    this.images = [];
    this.name = '';
    this.popularity = 0;
    this.type = '';;
    this.uri = '';
  }

  externalUrl: ExternalUrl;
  followers: Followers;
  genres: string[];
  href: string;
  id: string;
  images: Image[];
  name: string;
  popularity: number;
  type: string;
  uri: string;
}
