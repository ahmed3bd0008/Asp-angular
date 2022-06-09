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
    this.pagEventp.pageIndex=0
    this.pagEventp.pageSize=1
    this.getcity(this.pagEventp);
   }
   getcity(event:PageEvent){
     let url:string=this.api+'api/City/GetCityPaging';

    let parms:HttpParams=new HttpParams();
    this.pagEventp.pageIndex=0

    console.log(event)
    this.httpclient.get<any>(url,{params:{
      pageSize:event.pageSize.toString(),
      pageIndex:event.pageIndex.toString()

    }}).subscribe(
     (res:any)=>{

        if(!res.status){

          console.log( event.pageSize.toString()),
          console.log( event.pageIndex.toString())
          this.paginator.length=res.date.itemCount

          this.paginator.pageIndex=res.date.pageIndex
          this.paginator.pageSize=res.date.pageSize
          this.paginator._intl.itemsPerPageLabel="hkghk"
          //this.paginator.hasNextPage=res.date.hasNext
        // this.paginator.hasPreviousPage=res.date.hasPrevious
          console.log( res.date.itemCount)
          console.log( res.date)

        this.cities= new MatTableDataSource<City>(res.date.date as City[]) ;
       // this.cities.paginator=this.paginator;

        }else{
          console.log("error")
        }
      },error=>{
        console.error(error);
      }
    )
  }


}
