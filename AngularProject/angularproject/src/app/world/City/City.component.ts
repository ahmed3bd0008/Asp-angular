import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import{ HttpClient }from'@angular/common/http';
import { City } from './City';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-City',
  templateUrl: './City.component.html',
  styleUrls: ['./City.component.css']
})
export class CityComponent implements OnInit {

private api:string=environment.apiUrl;
public cities !: MatTableDataSource<City>;
@ViewChild (MatPaginator)paginator !:MatPaginator
public displayedColumns: string[] = ['id', 'name', 'lat', 'lon'];
  constructor(private httpclient:HttpClient){

  }

   ngOnInit() {
this.getcity();
   }
   getcity(){
    this.httpclient.get<any>(this.api+'api/City').subscribe(
     (res:any)=>{
        console.log(res)
        console.log(res.status)
        if(!res.status){
          console.log(typeof(res.date))
        this.cities= new MatTableDataSource<City>(res.date as City[]) ;
        this.cities.paginator=this.paginator;
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
