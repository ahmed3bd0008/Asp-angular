import { Routes, RouterModule } from '@angular/router';
import { CityComponent } from './City/City.component';
import { EditCityComponent } from './City/edit-city/edit-city.component';
import { CounteryComponent } from './countery/countery.component';

const routes: Routes = [


  {path:'city',component:CityComponent},
  {path:'editCity/:id',component:EditCityComponent},
  {path:'countery',component:CounteryComponent}


];
export const WorldRoutes = RouterModule.forChild(routes);
