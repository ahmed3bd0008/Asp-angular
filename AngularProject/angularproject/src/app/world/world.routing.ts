import { Routes, RouterModule } from '@angular/router';
import { CityComponent } from './City/City.component';
import { CounteryComponent } from './countery/countery.component';

const routes: Routes = [

  {path:'city',component:CityComponent},
  {path:'countery',component:CounteryComponent}


];
export const WorldRoutes = RouterModule.forChild(routes);
