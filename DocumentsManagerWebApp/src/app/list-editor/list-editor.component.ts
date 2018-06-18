import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FullUserData } from '../list-admin/FullUserData';
import { ManageToken } from '../manage-token';
import { EditorService } from './editor.service';

@Component({
  selector: 'app-list-editor',
  templateUrl: './list-editor.component.html',
  styleUrls: ['./list-editor.component.css']
})

  export class ListEditorsComponent{
    addFriendImgPath: string;
    pageTitle: string = "User List";
    listFilter: string = "";
    users: Array<FullUserData> = [];
    activeToken:string;
    tokenManagment:ManageToken;
  
    constructor(
      private editorService : EditorService, 
      private router: Router
    ) {
      this.tokenManagment=new ManageToken;
      this.addFriendImgPath = '/media/add.png';
      this.activeToken=this.tokenManagment.getToken();
      this.loadUsers(this.activeToken);
    }
    showErrorMessage(error:any){
      alert(error);
    }
    loadUsers(token: string ){
      this.editorService.getAllEditors(token).subscribe(response => this.users=response), 
        error => this.showErrorMessage(error);
    }
    addFriendUser(id:string){
      console.log(id);
    }
    modifyUser(id:string){
      this.router.navigate((['/modifyEditor']), { queryParams: { userToModify: id} });
    }
    deleteUser(id:string){
      this.editorService.deleteEditor(this.activeToken,id).subscribe(response => window.location.reload()), 
      error => this.showErrorMessage(error);
    }
    addUser(){
      this.router.navigate((['/newEditor']));
    }
  }

