import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FullUserData } from './FullUserData';

import { ManageToken } from '../manage-token';
import { AdminService } from './admin.service';
import { ModifyAdminComponent } from '../modify-admin/modify-admin.component';

@Component({
  selector: 'app-list-admins',
  templateUrl: './list-admins.component.html',
  styleUrls: ['./list-admins.component.css']
})
export class ListAdminsComponent {
  addFriendImgPath: string;
  pageTitle: string = "User List";
  listFilter: string = "";
  users: Array<FullUserData> = [];
  activeToken:string;
  tokenManagment:ManageToken;

  constructor(
    private adminService : AdminService, 
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
    this.adminService.getAllAdmins(token).subscribe(response => this.users=response), 
      error => this.showErrorMessage(error);
  }
  addFriendUser(id:string){
    console.log(id);
  }
  modifyUser(id:string){
    
    this.router.navigate((['/modifyAdmin']), { queryParams: { userToModify: id} });
  }
  deleteUser(id:string){
    this.adminService.deleteAdmin(this.activeToken,id).subscribe(response => window.location.reload()), 
    error => this.showErrorMessage(error);
  }
  addUser(){
    this.router.navigate((['/newAdmin']));
  }
}


