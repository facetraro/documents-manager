import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { Http, Response } from '@angular/http';
import { Url } from 'src/app/url';
import { Observable } from 'rxjs';
import '../rxjs-operators';
import { Review } from './review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  newReview(token : string, newReview:Review) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/RankDocuments/?token="+token;
    return this.httpService.post(url,newReview)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}

