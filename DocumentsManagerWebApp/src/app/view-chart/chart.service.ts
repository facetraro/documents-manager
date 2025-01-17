import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { Http, Response } from '@angular/http';
import { Url } from 'src/app/url';
import { Observable } from 'rxjs';
import '../rxjs-operators';
import { Chart } from 'src/app/view-chart/chart';

@Injectable({
  providedIn: 'root'
})
export class ChartService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  modifyGetChart(userId:string, dateOne:string, dateTwo:string, token : string) : Observable<Chart> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/ModifiersChart/?id="+userId+"&dateOne="+dateOne+"&dateTwo="+dateTwo+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <Chart> (response.json()))
    .catch(this.handleError);
  };
  createGetChart(userId:string, dateOne:string, dateTwo:string, token : string) : Observable<Chart> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/CreatorsChart/?id="+userId+"&dateOne="+dateOne+"&dateTwo="+dateTwo+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <Chart> (response.json()))
    .catch(this.handleError);
  };

  private handleError(error: Response) {
    console.error(error);
   
    this.specificError=error.json();
    alert(this.specificError.message || 'Se perdio la conexion con la Api.');
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.');
  }
}
