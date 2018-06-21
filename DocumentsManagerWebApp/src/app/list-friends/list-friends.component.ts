import { Component, OnInit } from '@angular/core';
import { FullUserData } from '../list-admin/FullUserData';
import { ManageToken } from '../manage-token';
import { FriendshipService } from '../friendship.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-friends',
  templateUrl: './list-friends.component.html',
  styleUrls: ['./list-friends.component.css']
})
export class ListFriendsComponent implements OnInit {
  ngOnInit() {
   
  }
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
    this.loadFriends(this.activeToken);
  }
  showErrorMessage(error:any){
    alert(error);
  }

  viewProfile(id:string,username:string){
    console.log(id);
    console.log(username);
    this.router.navigate((['/profile']), { queryParams: { userToView: username, userId: id } });
  }
 
  loadFriends(token: string ){
    this.friendshipService.getAllFriends(token).subscribe(response => this.users=response), 
      error => this.showErrorMessage(error);
  }
}

