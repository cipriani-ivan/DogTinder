import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PlacesComponent } from './places.component';

const routes: Routes = [
  {
    path: '',
    component: PlacesComponent,
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: [PlacesComponent],
})
export class PlacesModule {}
