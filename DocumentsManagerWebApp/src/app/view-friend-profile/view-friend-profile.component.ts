import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../list-document/document.service';
import { ManageToken } from '../manage-token';
import { DocumentModel } from '../list-document/document-model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-friend-profile',
  templateUrl: './view-friend-profile.component.html',
  styleUrls: ['./view-friend-profile.component.css']
})
export class ViewFriendProfileComponent implements OnInit {
    service:DocumentService;
    tokenManagment:ManageToken;
    activeToken:string;
    username:string;
    documents:DocumentModel[];
    userId:string;
  
    constructor( service:DocumentService, private router: Router, private activatedRoute: ActivatedRoute) { 
      this.service=service;
      this.documents=[];
      this.tokenManagment=new ManageToken;
      this.activeToken=this.tokenManagment.getToken();
    }
  
    showErrorMessage(error:any){
      alert(error);
    }

    printDocument(id:string){
      this.router.navigate((['/printDocument']), { queryParams: { idDoc: id} });
    }
  
    reviewDocument(id:string){
      this.router.navigate((['/reviewDocument']), { queryParams: { idDoc: id} });
    }

    loadDocuments(token: string , id :string ){
      this.service.getDocumentsByUser(token,id).subscribe(response => this.documents=response), 
        error => this.showErrorMessage(error);
    }
  
    ngOnInit() {
      this.activatedRoute.queryParams
      .filter(params => params.userToView)
      .subscribe(params => {
        this.username = params.userToView;
      });  
      this.activatedRoute.queryParams
      .filter(params => params.userId)
      .subscribe(params => {
        this.userId = params.userId;
      });  
      this.loadDocuments(this.activeToken, this.userId);
       }
  
}
