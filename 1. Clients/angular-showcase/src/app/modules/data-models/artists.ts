import { Artist } from "./artist";

export class Artists {
  constructor() {
    this.href = '';
    this.limit = 0;
    this.next = '';
    this.offset = 0;
    this.previous = '';
    this.total = 0;
    this.items = [];
  }

  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: Artist[];
}
