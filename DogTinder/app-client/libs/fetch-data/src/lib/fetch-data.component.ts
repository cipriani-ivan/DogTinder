import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Appointment } from './models/appointment';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'ad-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent implements OnInit {
  // to move to base component
  protected ngUnsubscribe: Subject<void> = new Subject();
  public appointments: Appointment[] = [];
  private HTTP: HttpClient;
  private BaseURL: string;

  constructor(http: HttpClient) {
    this.HTTP = http;

    // to retrieve
    this.BaseURL = 'https://localhost:44345/';
  }

  ngOnInit(): void {
    this.HTTP.get<Appointment[]>(`${this.BaseURL}appointment`)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((result) => {
        this.appointments = result;
      });
  }
}
