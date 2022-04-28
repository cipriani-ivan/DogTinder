import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'fetch-data',
    loadChildren: () => import('@ad/fetch-data').then((x) => x.FetchDataModule),
  },
  {
    path: 'owners',
    loadChildren: () => import('@ad/owners').then((x) => x.OwnerModule),
  },
  {
    path: 'dogs',
    loadChildren: () => import('@ad/dogs').then((x) => x.DogsModule),
  },
  {
    path: 'places',
    loadChildren: () => import('@ad/places').then((x) => x.PlacesModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
