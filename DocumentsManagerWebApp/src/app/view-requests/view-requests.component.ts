import { Component, OnInit } from '@angular/core';
import { FullUserData } from '../list-admin/FullUserData';
import { ManageToken } from '../manage-token';
import { Router } from '@angular/router';
import { FriendshipService } from '../friendship.service';

@Component({
  selector: 'app-view-requests',
  templateUrl: './view-requests.component.html',
  styleUrls: ['./view-requests.component.css']
})
export class ViewRequestsComponent {
  addFriendImgPath: string;
  pageTitle: string = "User List";
  listFilter: string = "";
  users: Array<FullUserData> = [];
  activeToken:string;
  tokenManagment:ManageToken;

  constructor(
    private friendshipService : FriendshipService, 
    private router: Router
  ) {
    this.tokenManagment=new ManageToken;
    this.users=[];
    this.activeToken=this.tokenManagment.getToken();
    this.loadRequests(this.activeToken);
  }
  showErrorMessage(error:any){
    alert(error);
  }
  loadRequests(token: string ){
    this.friendshipService.getAllRequests(token).subscribe(response => this.users=response), 
      error => this.showErrorMessage(error);
  }
  addFriendUser(id:string){
    this.friendshipService.addFriend(this.activeToken, id).subscribe(response => {this.showErrorMessage("Se acepto la solicitud de amistad."),  window.location.reload()}, error => this.showErrorMessage(error));
  }
  rejectFriendRequest(id:string){
    this.friendshipService.rejectFriend(this.activeToken, id).subscribe(response => {this.showErrorMessage("Se rechazo la solicitud de amistad."),  window.location.reload()}, error => this.showErrorMessage(error));
  }
  addUser(){
    this.router.navigate((['/newAdmin']));
  }
}

