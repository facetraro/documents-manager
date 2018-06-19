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
  chart:Chart;
  activeToken="";
  dateOne:string;
  dateTwo:string;
  id:string;
  public lineChartData:Array<any>  = [{data: [], label: 'Documentos'}];
  public lineChartLabels:Array<any> =  [];
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
    service.modifyGetChart(this.id,this.dateOne,this.dateTwo,this.activeToken).subscribe(response => this.showChart(response)), 
    error => this.showErrorMessage(error);
  }

  showChart(response:Chart){
    this.chart=response;
    let datas:Array<string>  = [];
    this.chart.values.forEach(element => {
      datas.push(element.value);
      this.lineChartLabels.push(element.date);
    });
    this.lineChartData=[{data: datas, label: 'Documentos'}];
  }

  showErrorMessage(error:any){
    alert(error);
  }
  ngOnInit() {
  }

  public lineChartOptions:any = {
    responsive: true
  };
  public lineChartColors:Array<any> = [
    { // grey
      backgroundColor: 'rgba(0,255,0,0.2)',
      borderColor: 'rgba(0,255,0,1)',
      pointBackgroundColor: 'rgba(0,255,0,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(0,255,0,0.8)'
    }
  ];
  public lineChartLegend:boolean = true;
  public lineChartType:string = 'line';
  
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }

}
