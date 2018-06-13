import { Injectable } from '@angular/core';
import { Token } from 'src/app/token';
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

  logIn(newSessionUser:User) : Observable<Token> {
    let url = "http://localhost:20981/api/Login/?Username="+newSessionUser.username;
    return this.httpService.post(url,newSessionUser)
    .map((response : Response) => <Token> response.json())
    .do(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data)))
    .catch(this.handleError);
}
private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json().error|| 'Server error');
  }
}
