import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ad-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  isExpanded = false;
  constructor(private readonly router: Router) {}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onClickNavigate(path: string): void {
    this.router.navigateByUrl(`/${path}`);
  }
}
