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
  constructor(service:ChartService, _currentRoute:ActivatedRoute) { 
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    let id = "" + _currentRoute.snapshot.params['id']; 
    let dateOne = "" + _currentRoute.snapshot.params['dateOne']; 
    let dateTwo = "" + _currentRoute.snapshot.params['dateTwo']; 
    service.modifyGetChart(id,dateOne,dateTwo,this.activeToken).subscribe(response => this.chart=response), 
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
