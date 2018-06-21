import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../list-document/document.service';
import { ActivatedRoute } from '@angular/router';
import { ManageToken } from '../manage-token';

@Component({
  selector: 'app-print-document',
  templateUrl: './print-document.component.html',
  styleUrls: ['./print-document.component.css']
})
export class PrintDocumentComponent implements OnInit {

  tokenManagment:ManageToken;
  documentInHTML:string;
  constructor(   
    private documentService: DocumentService,
    private activatedRoute: ActivatedRoute
  ) {
      this.tokenManagment=new ManageToken;   
      this.documentInHTML="";   
   }

  ngOnInit() {
    let idDoc="";
    this.activatedRoute.queryParams
    .filter(params => params.idDoc)
    .subscribe(params => {
      idDoc = params.idDoc;
    });  
    let token=this.tokenManagment.getToken();
    this.loadDocument(token, idDoc);
  }

  showErrorMessage(error:any){
    alert(error);
  }
  loadDocumentDiv(htmlDocument : string){
    var div = document.createElement('div');
    div.innerHTML = htmlDocument;
    document.getElementById("documentDiv").appendChild(div);
  }
  loadDocument(token: string , id:string){
    this.documentService.printDocument(token, id).subscribe(response => this.loadDocumentDiv(response)), 
      error => this.showErrorMessage(error);
  }
}
