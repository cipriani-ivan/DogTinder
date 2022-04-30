import { Component, OnInit } from '@angular/core';
import { Place } from 'output/models/place';
import { APIClient } from 'output';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'ad-places',
  templateUrl: './places.component.html',
})
export class PlacesComponent implements OnInit {
  public places: Place[] = [];

  profileForm = new FormGroup({
    address: new FormControl('', [Validators.required]),
  });

  submitted = false;

  observablePlaceList: BehaviorSubject<Place[]> = new BehaviorSubject<Place[]>(
    []
  );

  get observableList(): Observable<Place[]> {
    return this.observablePlaceList.asObservable();
  }

  constructor(private api: APIClient) {}

  ngOnInit(): void {
    this.api.getPlace().subscribe((places) => {
      this.places = places;
      this.observablePlaceList.next(this.places);
    });
  }

  async onSubmit(): Promise<void> {
    if (this.profileForm?.valid) {
      const place = JSON.stringify(this.profileForm.value);
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
      });

      this.api.postPlace(place, { headers: headers }).subscribe(() => {
        this.places.push(JSON.parse(place));
        this.observablePlaceList.next(this.places);
        this.profileForm.controls['address'].setValue('');
      });
    }
  }
}
