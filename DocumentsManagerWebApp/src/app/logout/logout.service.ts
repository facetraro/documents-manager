import { Injectable } from '@angular/core';
import { Token } from 'src/app/token';
import { MessageError } from 'src/app/message-error';
import { User } from 'src/app/User';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
// Add the RxJS Observable operators we need in this app.
import '../rxjs-operators';
import { Url } from 'src/app/url';


@Injectable({
  providedIn: 'root'
})
export class LogoutService {

  constructor(private httpService: Http) {}
    specificError:MessageError;


  logOut(token : Token) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/LogOut/?token="+token.token;
    return this.httpService.post(url,token)
    .map((response: Response) => <string> response.json() )
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
