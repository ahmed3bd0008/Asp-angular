import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import{ HttpClient ,HttpParams}from'@angular/common/http';
import { City } from './City';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator,PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-City',
  templateUrl: './City.component.html',
  styleUrls: ['./City.component.css']
})
export class CityComponent implements OnInit {

private api:string=environment.apiUrl;
public cities !: MatTableDataSource<City>;
@ViewChild (MatPaginator)paginator !:MatPaginator
pagEventp=new PageEvent();
public displayedColumns: string[] = ['id', 'name', 'lat', 'lon'];
  constructor(private httpclient:HttpClient){

  }

  ngOnInit() {
    this.pagEventp.pageIndex=1
    this.pagEventp.pageSize=1
    this.getcity(this.pagEventp);
   }
   getcity(event:PageEvent){
     let url:string=this.api+'api/GetCityPaging';
    let parms:HttpParams=new HttpParams();
    parms.set("pageSize",event.pageSize);
    parms.set("pageIndex",event.pageIndex)
    this.httpclient.get<any>(url,{params:parms}).subscribe(
     (res:any)=>{
        console.log(res)
        console.log(res.status)
        if(!res.status){
          console.log(typeof(res.date))
          this.paginator.length=res.date.itemCount
          this.paginator.pageIndex=res.date.pageIndex
          this.paginator.pageSize=res.date.pageSize
        this.cities= new MatTableDataSource<City>(res.date.data as City[]) ;
       // this.cities.paginator=this.paginator;
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
