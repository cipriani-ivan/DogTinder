import { Component, OnInit } from '@angular/core';
import { Dog } from '../../../../output/models/dog';
import { APIClient } from '../../../../output';

@Component({
  selector: 'ad-dogs',
  templateUrl: './dogs.component.html',
})
export class DogsComponent implements OnInit {
  public dogs: Dog[] = [];

  constructor(private api: APIClient) {}

  ngOnInit(): void {
    this.api.getDog().subscribe((dogs) => (this.dogs = dogs));
  }
}
