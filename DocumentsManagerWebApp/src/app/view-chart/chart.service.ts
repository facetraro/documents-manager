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
    console.log(userId);
    let url = apiUrl.globalUrl+"/ModifiersChart/?id="+userId+"&dateOne="+dateOne+"&dateTwo="+dateTwo+"&token="+token;
    console.log(url);
    return this.httpService.get(url)
    .map((response: Response) => <Chart> (response.json()))
    .catch(this.handleError);
  };

  private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
