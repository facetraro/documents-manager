import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { MessageError } from '../message-error';
import { Observable } from 'rxjs';
import { FullUserData } from '../list-admin/FullUserData';
import { Url } from '../url';
import '../rxjs-operators';

@Injectable({
  providedIn: 'root'
})

export class EditorService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllEditors(token : string) : Observable<FullUserData[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Editor/?token="+token;
    console.log(url);
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData[]> response.json())
    .catch(this.handleError);
  };



  getEditor(token : string, id : string) : Observable<FullUserData> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Editor/?id="+id+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData> response.json())
    .catch(this.handleError);
  };

  newEditor(token : string, newUser:FullUserData) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Editor/?token="+token;
    return this.httpService.post(url,newUser)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };

  modifyEditor(token : string, modifiedUser:FullUserData) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Editor/?id="+modifiedUser.id+"&token="+token;
    return this.httpService.put(url,modifiedUser)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
  deleteEditor(token : string, id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Editor/?id="+id+"&token="+token;
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