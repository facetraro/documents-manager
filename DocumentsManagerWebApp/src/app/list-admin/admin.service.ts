import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { Http, Response } from '@angular/http';
import { Url } from 'src/app/url';
import { FullUserData } from './FullUserData';
import { Observable } from 'rxjs';
import '../rxjs-operators';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllAdmins(token : string) : Observable<FullUserData[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/Admins/?token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData[]> response.json())
    .catch(this.handleError);
  };

  getAdmin(token : string, id : string) : Observable<FullUserData> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Admin/?id="+id+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData> response.json())
    .catch(this.handleError);
  };

  newAdmin(token : string, newUser:FullUserData) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Admin/?token="+token;
    return this.httpService.post(url,newUser)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };

  modifyAdmin(token : string, newUser:FullUserData) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Admin/?id="+newUser.id+"?token="+token;
    console.log(newUser);
    return this.httpService.put(url,newUser)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
  deleteAdmin(token : string, id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Admin/?id="+id+"&token="+token;
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
