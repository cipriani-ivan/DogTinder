import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FetchDataComponent } from './fetch-data.component';

const routes: Routes = [
  {
    path: '',
    component: FetchDataComponent,
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FetchDataModule {}
