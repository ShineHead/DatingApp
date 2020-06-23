import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule //Configures the dependency injector for HttpClient with supporting services for XSRF. Automatically imported by HttpClientModule.
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
