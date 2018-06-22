import { Component, OnInit } from '@angular/core';
import { FullUserData } from '../list-admin/FullUserData';
import { ManageToken } from '../manage-token';
import { AdminService } from '../list-admin/admin.service';
import { Router } from '@angular/router';
import { EditorService } from '../list-editor/editor.service';
import { FriendshipService } from '../friendship.service';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent {
  addFriendImgPath: string;
  pageTitle: string = "User List";
  listFilter: string = "";
  users: Array<FullUserData> = [];
  activeToken:string;
  tokenManagment:ManageToken;

  constructor(
    private adminService : AdminService, 
    private editorService : EditorService, 
    private friendshipService : FriendshipService, 
    private router: Router
  ) {
    this.tokenManagment=new ManageToken;
    this.users=[];
    this.activeToken=this.tokenManagment.getToken();
    this.loadAdmins(this.activeToken);
  }
  showErrorMessage(error:any){
    alert(error);
  }
  loadAdmins(token: string ){
    this.adminService.getAllAdmins(token).subscribe(response => {this.addUsers(response), this.loadEditors(token)}), 
      error => this.showErrorMessage(error);
  }
  addUsers(user:Array<FullUserData>){
    user.forEach(element => {
      this.users.push(element);
    });
  }
  loadEditors(token: string ){
    this.editorService.getAllEditors(token).subscribe(response => this.addUsers(response)), 
      error => this.showErrorMessage(error);
  }
  addFriendUser(id:string){
   
    this.friendshipService.addFriend(this.activeToken, id).subscribe(response => this.showErrorMessage("Se le envio una solicitud al usuario."), error => this.showErrorMessage(error));
  }
  addUser(){
    this.router.navigate((['/newAdmin']));
  }
}

