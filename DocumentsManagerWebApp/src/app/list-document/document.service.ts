import { Injectable } from '@angular/core';
import { MessageError } from 'src/app/message-error';
import { Http, Response } from '@angular/http';
import { Url } from 'src/app/url';
import { Observable } from 'rxjs';
import '../rxjs-operators';
import { DocumentModel } from './document-model';


@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  constructor(
    private httpService: Http) { 
    }
    specificError:MessageError;

  getAllDocuments(token : string) : Observable<DocumentModel[]> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/Documents/?token="+token;
    return this.httpService.get(url)
    .map((response: Response) => <DocumentModel[]> response.json())
    .catch(this.handleError);
  };
  

  getDocument(token : string, id : string) : Observable<DocumentModel> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Document/?id="+id+"&token="+token;
    console.log(url);
    return this.httpService.get(url)
    .map((response: Response) => <DocumentModel> response.json())
    .catch(this.handleError);
  };

  newDocument(token : string, newDocument:DocumentModel) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Document/?token="+token;
    console.log(newDocument);
    return this.httpService.post(url,newDocument)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };

  modifyDocument(token : string, modifiedDocument:DocumentModel) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Document/?id="+modifiedDocument.id+"&token="+token;
    return this.httpService.put(url,modifiedDocument)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
  deleteDocument(token : string, id : string) : Observable<string> {
    let apiUrl= new Url;
    let url = apiUrl.globalUrl+"/api/Document/?id="+id+"&token="+token;
    return this.httpService.delete(url)
    .map((response: Response) => <string> response.json())
    .catch(this.handleError);
  };
  
private handleError(error: Response) {
    console.error(error);
    this.specificError=error.json();
    return Observable.throw(this.specificError.message || 'Se perdio la conexion con la Api.' );
  }
}
