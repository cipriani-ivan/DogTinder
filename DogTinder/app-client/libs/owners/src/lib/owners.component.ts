import { Component, OnInit } from '@angular/core';
import { Owner } from 'output/models/owner';
import { APIClient } from 'output';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'ad-owners',
  templateUrl: './owners.component.html',
})
export class OwnersComponent implements OnInit {
  owners: Owner[] = [];

  profileForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
  });

  submitted = false;

  observableOwnerList: BehaviorSubject<Owner[]> = new BehaviorSubject<Owner[]>(
    []
  );

  get observableList(): Observable<Owner[]> {
    return this.observableOwnerList.asObservable();
  }

  constructor(private api: APIClient) {}

  ngOnInit(): void {
    this.api.getOwner().subscribe((users) => {
      this.owners = users;
      this.observableOwnerList.next(this.owners);
    });
  }

  async onSubmit(): Promise<void> {
    if (this.profileForm?.valid) {
      const owner = JSON.stringify(this.profileForm.value);
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
      });

      this.api.postOwner(owner, { headers: headers }).subscribe(() => {
        this.owners.push(JSON.parse(owner));
        this.observableOwnerList.next(this.owners);
        this.profileForm.controls['name'].setValue('');
      });
    }
  }
}
