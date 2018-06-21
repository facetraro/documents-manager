import { Component, OnInit } from '@angular/core';
import { TopDocumentsService } from './top-documents.service';
import { ManageToken } from '../manage-token';
import { TopDocumentsModel } from './top-documents-model';

@Component({
  selector: 'app-top-documents',
  templateUrl: './top-documents.component.html',
  styleUrls: ['./top-documents.component.css']
})
export class TopDocumentsComponent implements OnInit {
  
  tokenManagment:ManageToken;
  activeToken:string;
  documents:TopDocumentsModel[];
  
  constructor(private service:TopDocumentsService) { 
    this.documents=[];
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    this.loadDocuments(this.activeToken);
  }

  loadDocuments(token: string ){
    this.service.getTopDocuments(token).subscribe(response => this.documents=response), 
      error => this.showErrorMessage(error);
  }

  showErrorMessage(error:any){
    alert(error);
  }

  ngOnInit() {
  }

}

