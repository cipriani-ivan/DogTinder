import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public appointments: Appointment[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Appointment[]>(baseUrl + 'appointment').subscribe(result => {
      this.appointments = result;
    }, error => console.error(error));
  }
}

interface Appointment {
	appointmentId: number;
    time: Date;
	place: string;
	dogs: Dog[];
}

interface Dog {
    name: string;
    breed: string;
}



