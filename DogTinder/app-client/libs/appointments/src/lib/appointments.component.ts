import { Component, OnInit } from '@angular/core';
import { Appointment } from 'output/models/appointment';
import { APIClient } from 'output';
import { Dog } from 'output/models/dog';
import { Owner } from 'output/models/owner';
import { Place } from 'output/models/place';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'ad-appointments',
  templateUrl: './appointments.component.html',
})
export class AppointmentsComponent implements OnInit {
  appointments: Appointment[] = [];
  dogs: Dog[] = [];
  owners: Owner[] = [];
  places: Place[] = [];

  profileForm = new FormGroup({
    placeid: new FormControl('', [Validators.required]),
    dogid: new FormControl('', [Validators.required]),
    time: new FormControl('', [Validators.required]),
  });

  submitted = false;

  observableAppointmentList: BehaviorSubject<Appointment[]> =
    new BehaviorSubject<Appointment[]>([]);

  get observableList(): Observable<Appointment[]> {
    return this.observableAppointmentList.asObservable();
  }

  constructor(private api: APIClient) {}

  ngOnInit(): void {
    this.api.getAppointment().subscribe((appointments) => {
      this.appointments = appointments;
      this.observableAppointmentList.next(this.appointments);
    });

    this.api.getDog().subscribe((dogs) => {
      this.dogs = dogs;
    });

    this.api.getPlace().subscribe((places) => {
      this.places = places;
    });
  }

  async onSubmit(): Promise<void> {
    // eslint-disable-next-line @typescript-eslint/no-this-alias
    const selfThis = this;
    if (this.profileForm?.valid) {
      const appointment = JSON.stringify(this.profileForm.value);
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
      });

      this.api
        .postAppointment(appointment, { headers: headers })
        .subscribe(() => {
          const dog = selfThis.dogs.find(
            (x) => x.dogId == selfThis.profileForm.controls['dogid'].value
          );
          const dogName = dog?.name;
          const dogBreed = dog?.breed;

          const place = selfThis.places.find(
            (x) => x.placeId == selfThis.profileForm.controls['placeid'].value
          )?.adress;

          const appointmentObject: Appointment = JSON.parse(appointment);

          if (dogName && dogBreed && place) {
            appointmentObject.dogs = [
              {
                dogId: selfThis.profileForm.controls['dogid'].value,
                name: dogName,
                breed: dogBreed,
                ownerId: 0,
                owner: {
                  name: dog.owner.name,
                  ownerId: 0,
                },
              },
            ];
            appointmentObject.place = place;
          }

          this.appointments.push(appointmentObject);
          this.observableAppointmentList.next(this.appointments);
          this.profileForm.controls['dogid'].setValue('');
          this.profileForm.controls['placeid'].setValue('');
          this.profileForm.controls['time'].setValue('');
        });
    }
  }
}
