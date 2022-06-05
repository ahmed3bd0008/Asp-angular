import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { City } from './City/City';
@Component({
  selector: 'app-world',
  templateUrl: './world.component.html',
  styleUrls: ['./world.component.css']
})
export class WorldComponent implements OnInit {
private api:string=environment.apiUrl;
private cities:City[]=[];
 constructor(private httpclient:HttpClient) {

   }

  ngOnInit() {



}
}
