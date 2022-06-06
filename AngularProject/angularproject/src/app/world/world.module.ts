import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorldComponent } from './world.component';
import { CityComponent } from './City/City.component';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { WorldRoutes } from './world.routing';
import { CounteryComponent } from './countery/countery.component';
import { AngularmaterialModule } from '../Shared/angularmaterial.module';


@NgModule({
  imports: [
    CommonModule,

    HttpClientModule,
    AppRoutingModule,
    WorldRoutes,
    AngularmaterialModule

  ],
  exports:[
    WorldComponent,
  ],
  declarations: [
    WorldComponent,
    CityComponent,
    CounteryComponent

  ],


})
export class WorldModule { }
