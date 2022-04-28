import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { NavMenuModule } from '@ad/nav-menu';
import { APIClient } from 'output';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NavMenuModule.forRoot(),
    ReactiveFormsModule,
  ],
  providers: [APIClient],
  bootstrap: [AppComponent],
})
export class AppModule {}
