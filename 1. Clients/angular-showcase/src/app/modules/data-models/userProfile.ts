import { ExplicitContentFilter } from './explicitContentFilter';
import { ExternalUrl } from './externalUrl';
import { Followers } from './followers';
import { Image } from './image';
export class UserProfile {
  constructor() {
    this.country = '';
    this.displayName = '';
    this.emailAddress = '';
    this.explicitContentFilter = new ExplicitContentFilter();
    this.externalUrls = new ExternalUrl();
    this.followers = new Followers();
    this.href = '';
    this.id = '';
    this.images = [];
    this.product = '';
    this.type = '';
    this.uri = '';
  }

  country: string;
  displayName: string;
  emailAddress: string;
  explicitContentFilter: ExplicitContentFilter;
  externalUrls: ExternalUrl;
  followers: Followers;
  href: string;
  id: string;
  images: Image[];
  product: string;
  type: string;
  uri: string;
}
