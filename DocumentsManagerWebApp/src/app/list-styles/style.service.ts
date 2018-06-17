import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { Http, Response } from '@angular/http';
import { Url } from 'src/app/url';
import { StyleModel } from './styleModel';
import { Observable } from 'rxjs';
import '../rxjs-operators';

@Injectable({
  providedIn: 'root'
})
export class StyleService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllStyles(token : string) : Observable<StyleModel[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/viewStyles/?token="+token;
    console.log(url);
    return this.httpService.get(url)
    .map((response: Response) => <StyleModel[]> response.json())
    .catch(this.handleError);
  };

  getStyle(token : string, id : string) : Observable<StyleModel> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/StyleClass/?id="+id+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <StyleModel> response.json())
    .catch(this.handleError);
  };

  newStyle(token : string, newStyle:StyleModel) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/StyleClass/?token="+token;
    return this.httpService.post(url,newStyle)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };

  modifyStyle(token : string, modifiedStyle:StyleModel) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/StyleClass/?id="+modifiedStyle.id+"&token="+token;
    return this.httpService.put(url,modifiedStyle)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
  deleteStyle(token : string, id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/StyleClass/?id="+id+"&token="+token;
    return this.httpService.delete(url)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
