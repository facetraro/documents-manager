import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { Http, Response } from '@angular/http';
import { Url } from 'src/app/url';
import { Observable } from 'rxjs';
import '../rxjs-operators';
import { Format } from './format';

@Injectable({
  providedIn: 'root'
})
export class FormatService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllFormats(token : string) : Observable<Format[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Format/?token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <Format[]> response.json())
    .catch(this.handleError);
  };
  

  getFormat(token : string, id : string) : Observable<Format> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Format/?id="+id+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <Format> response.json())
    .catch(this.handleError);
  };

  newFormat(token : string, newFormat:Format) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Format/?token="+token;
    return this.httpService.post(url,newFormat)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };

  modifyFormat(token : string, modifiedUser:Format) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Format/?id="+modifiedUser.id+"&token="+token;
    return this.httpService.put(url,modifiedUser)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
  deleteFormat(token : string, id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Format/?id="+id+"&token="+token;
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
