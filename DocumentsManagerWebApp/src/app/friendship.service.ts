import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { MessageError } from './message-error';
import { Observable } from 'rxjs';
import { FullUserData } from './list-admin/FullUserData';
import { Url } from './url';
import './rxjs-operators';

@Injectable({
  providedIn: 'root'
})
export class FriendshipService {

  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllFriends(token : string) : Observable<FullUserData[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Friends/?token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData[]> response.json())
    .catch(this.handleError);
  };

  getAllRequests(token : string) : Observable<FullUserData[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/ManageRequests/?token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData[]> response.json())
    .catch(this.handleError);
  };

  getFriend(token : string, id : string) : Observable<FullUserData> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Document/?id="+id+"&token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <FullUserData> response.json())
    .catch(this.handleError);
  };

  addFriend(token : string,  id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Friends/?userId="+id+"&token="+token;
    return this.httpService.post(url,id)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
  rejectFriend(token : string, id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/ManageRequests/?userId="+id+"&token="+token;
    return this.httpService.delete(url,id)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };


private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
