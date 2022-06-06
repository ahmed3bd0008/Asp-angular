import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import{ HttpClient }from'@angular/common/http';
import { City } from './City';

@Component({
  selector: 'app-City',
  templateUrl: './City.component.html',
  styleUrls: ['./City.component.css']
})
export class CityComponent implements OnInit {

  private api:string=environment.apiUrl;
public cities :City[]=[];
public displayedColumns: string[] = ['id', 'name', 'lat', 'lon'];
  constructor(private httpclient:HttpClient){

  }

   ngOnInit() {
this.getcity();
   }
   getcity(){
    this.httpclient.get<any>(this.api+'api/City').subscribe(
     (res:any)=>{
        console.log(res.status)
        if(res.status){
          console.log(typeof(res.date))
        this.cities=res.date as City[];
        console.log(res.date)
        }else{
          console.log("error")
        }
      },error=>{
        console.error(error);
      }
    )
  }


}
