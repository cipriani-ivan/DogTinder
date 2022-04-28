import { Component, OnInit } from '@angular/core';
import { Appointment } from 'output/models/appointment';
import { APIClient } from 'output';

@Component({
  selector: 'ad-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public appointments: Appointment[] = [];

  constructor(private api: APIClient) {}

  ngOnInit(): void {
    this.api.getAppointment().subscribe((users) => (this.appointments = users));
  }
}
