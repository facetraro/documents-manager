import { Component, OnInit } from '@angular/core';
import { DocumentService } from './document.service';
import { DocumentModel } from './document-model';
import { ManageToken } from '../manage-token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-document',
  templateUrl: './list-document.component.html',
  styleUrls: ['./list-document.component.css']
})
export class ListDocumentComponent implements OnInit {
  service:DocumentService;
  tokenManagment:ManageToken;
  activeToken:string;
  documents:DocumentModel[];

  constructor( service:DocumentService, private router: Router ) { 
    this.service=service;
    this.documents=[];
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    this.loadDocuments(this.activeToken);
  }

  showErrorMessage(error:any){
    alert(error);
  }
  addDocument(){
    this.router.navigate((['/newDocument']));
  }

  modifyDocument(id:string){
    this.router.navigate((['/modifyDocument']), { queryParams: { idDoc: id} });
  }

  deleteDocument(id:string){
    this.service.deleteDocument(this.tokenManagment.getToken(),id).subscribe(response => window.location.reload()), 
    error => this.showErrorMessage(error);
  }
  loadDocuments(token: string ){
    this.service.getAllDocuments(token).subscribe(response => this.documents=response), 
      error => this.showErrorMessage(error);
  }

  ngOnInit() {
     }

}
