import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DogsComponent } from './dogs.component';

const routes: Routes = [
  {
    path: '',
    component: DogsComponent,
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: [DogsComponent],
})
export class DogsModule {}
