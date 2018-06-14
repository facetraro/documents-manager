import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FullUserData } from './FullUserData';
import { GetAllUsersService } from 'src/app/list-users/get-all-users.service';
import { ManageToken } from '../manage-token';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css']
})
export class ListUsersComponent {
  addFriendImgPath: string;
  pageTitle: string = "User List";
  listFilter: string = "";
  users: Array<FullUserData> = [];
  activeToken:string;
  tokenManagment:ManageToken;

  constructor( private service : GetAllUsersService, private router: Router) {
    this.tokenManagment=new ManageToken;
    this.addFriendImgPath = '/media/add.png';
    this.activeToken=this.tokenManagment.getToken();
    this.loadUsers(this.activeToken);
  }
  showErrorMessage(error:any){
    alert(error);
  }
  loadUsers(token: string ){
    this.service.getAllUsers(token).subscribe(response => this.users=response), 
      error => this.showErrorMessage(error);
  }
  addFriendUser(id:string){
    console.log(id);
  }
  modifyUser(id:string){
    console.log(id);
  }
  deleteUser(id:string){
    console.log(id);
  }
}


