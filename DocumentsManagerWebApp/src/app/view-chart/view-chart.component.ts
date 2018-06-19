import { Component, OnInit } from '@angular/core';
import { ChartService } from './chart.service';
import { ManageToken } from '../manage-token';
import { Chart } from './chart';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-chart',
  templateUrl: './view-chart.component.html',
  styleUrls: ['./view-chart.component.css']
})
export class ViewChartComponent implements OnInit {
  tokenManagment: ManageToken;
  chart:Chart[];
  activeToken="";
  dateOne:string;
  dateTwo:string;
  id:string;
  constructor(service:ChartService, _currentRoute:ActivatedRoute) { 
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    _currentRoute.queryParams
    .filter(params => params.idUser)
    .subscribe(params => {
      this.id = params.idUser;
    });  
    _currentRoute.queryParams
    .filter(params => params.dateOne)
    .subscribe(params => {
      this.dateOne = params.dateOne;
    });  
    _currentRoute.queryParams
    .filter(params => params.dateTwo)
    .subscribe(params => {
      this.dateTwo = params.dateTwo;
    });  

    console.log(this.dateOne);
    console.log(this.dateTwo);
    service.modifyGetChart(this.id,this.dateOne,this.dateTwo,this.activeToken).subscribe(response => console.log(response)), 
    error => this.showErrorMessage(error);
  }

  showChart(response:Chart[]){
    this.chart=response;
    console.log(this.chart);
  }

  showErrorMessage(error:any){
    alert(error);
  }
  ngOnInit() {
  }

}
