import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorldComponent } from './world.component';
import { CityComponent } from './City/City.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports:[
    WorldComponent,
  ],
  declarations: [
    WorldComponent,
    CityComponent
  ]
})
export class WorldModule { }
