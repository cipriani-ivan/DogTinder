import { Component, OnInit } from '@angular/core';
import { Place } from '../../../../output/models/place';
import { APIClient } from '../../../../output';

@Component({
  selector: 'ad-places',
  templateUrl: './places.component.html',
})
export class PlacesComponent implements OnInit {
  public places: Place[] = [];

  constructor(private api: APIClient) {}

  ngOnInit(): void {
    this.api.getPlace().subscribe((places) => (this.places = places));
  }
}
