import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorldComponent } from './world.component';
import { CityComponent } from './City/City.component';
import { CounteryComponent } from './countery/countery.component';
import { WorldRoutes } from './world.routing';

@NgModule({
  imports: [
    CommonModule,
    WorldRoutes
  ],
  exports:[
    WorldComponent,
  ],
  declarations: [
    WorldComponent,
    CityComponent,
    CounteryComponent
  ]
})
export class WorldModule { }
