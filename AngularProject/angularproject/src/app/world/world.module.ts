import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorldComponent } from './world.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports:[
    WorldComponent
  ],
  declarations: [WorldComponent]
})
export class WorldModule { }
