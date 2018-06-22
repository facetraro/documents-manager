import { Component, OnInit } from '@angular/core';
import { ManageToken } from 'src/app/manage-token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {
 
private tokenManagment:ManageToken;
private activeToken:string;
private role:string;
  constructor(private router: Router) {
    this.tokenManagment=new ManageToken;
    this.role=this.tokenManagment.getRole();
    this.activeToken=this.tokenManagment.getToken();
    }

  goListAdmins(){
    this.router.navigate((['/admins']));
  }
  goListEditors(){
    this.router.navigate((['/editors']));
  }
  goListStyles(){
    this.router.navigate((['/styles']));
  }
  goListFormats(){
    this.router.navigate((['/formats']));
  }
  goListDocuments(){
    this.router.navigate((['/documents']));
  }
  goRequests(){
    this.router.navigate((['/friendRequests']));
  }
  goAllUsers(){
    this.router.navigate((['/users']));
  }
  goListFriends(){
    this.router.navigate((['/friends']));
  }
  ngOnInit() {
  }

}
