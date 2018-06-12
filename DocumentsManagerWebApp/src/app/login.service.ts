import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(
    private httpService: Http) { }

  logIn(newSessionUser:User) {
    console.log("tuvieja");
    let url = "http://localhost:20981/api/Login/?Username="+newSessionUser.username;
    return this.httpService.post(url,newSessionUser);
    //PEGARLE A LA API
  }
}
