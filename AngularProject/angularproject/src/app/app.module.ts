import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WorldModule } from './world/world.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import{HttpClient, HttpClientModule}from'@angular/common/http';
///import { API_BASE_URL } from 'src/app/services/api.generated.clients'
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
@NgModule({
  declarations: [
    AppComponent,
      NavbarComponent
   ],
  imports: [
    BrowserModule,
    WorldModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    BrowserAnimationsModule,
  

  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
