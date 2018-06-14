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
export class LogoutService {

  private WEB_API_URL : string = 'http://localhost:20981/api/LogOut';

  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  logOut(token : Token) : Observable<string> {
    let url = "http://localhost:20981/api/LogOut";
    return this.httpService.post(url,token)
    .map((response: Response) => <string> response.json() )
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message);
  }
}
