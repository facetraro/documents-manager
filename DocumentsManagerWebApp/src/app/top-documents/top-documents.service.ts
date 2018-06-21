import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { MessageError } from '../message-error';
import { Observable } from 'rxjs';
import { Url } from '../url';
import '../rxjs-operators';
import { TopDocumentsModel } from './top-documents-model';

@Injectable({
  providedIn: 'root'
})

export class TopDocumentsService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getTopDocuments(token : string) : Observable<TopDocumentsModel[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/RankDocuments/?token="+token;
    console.log(url);
    return this.httpService.get(url)
    .map((response: Response) => <TopDocumentsModel[]> response.json())
    .catch(this.handleError);
  };

  private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}