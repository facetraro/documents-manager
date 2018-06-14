import { Injectable } from '@angular/core';
import { Token } from 'src/app/token';
import { MessageError } from 'src/app/message-error';
import { User } from 'src/app/User';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
// Add the RxJS Observable operators we need in this app.
import '../rxjs-operators';


@Injectable({
  providedIn: 'root'
})

export class LoginService {

  private WEB_API_URL : string = 'http://localhost:20981/api/Login/?Username=';

  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  logIn(newSessionUser:User) : Observable<string> {
    let url = "http://localhost:20981/api/Login/?Username="+newSessionUser.username;
    return this.httpService.post(url,newSessionUser)
    .map((response: Response) => <string> response.json() )
    //.map((response : Response) => <Token> response.json())
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
