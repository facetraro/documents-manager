import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { User } from 'src/app/User';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
// Add the RxJS Observable operators we need in this app.
import '../rxjs-operators';
import { Url } from 'src/app/url';
import { LoginModel } from './login-model';


@Injectable({
  providedIn: 'root'
})

export class LoginService {

  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  logIn(newSessionUser:User) : Observable<LoginModel> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Login/?Username="+newSessionUser.username;
    return this.httpService.post(url,newSessionUser)
    .map((response: Response) => <LoginModel> response.json())
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
