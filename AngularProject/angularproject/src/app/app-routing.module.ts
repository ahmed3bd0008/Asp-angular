import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CityComponent } from './world/City/City.component';

import { WorldComponent } from './world/world.component';

const routes: Routes = [
  {path:'',component:CityComponent,pathMatch:'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
