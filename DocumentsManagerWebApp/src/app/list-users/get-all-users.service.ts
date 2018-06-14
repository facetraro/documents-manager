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
export class GetAllUsersService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllUsers(token : string) : Observable<FullUserData[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/Admins/?token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData[]> response.json())
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
